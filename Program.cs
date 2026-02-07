using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProductApi.Data;
using ProductApi.Middleware;
using ProductApi.Models;
using ProductApi.Security;
using ProductApi.Services;
using ProductApi.Services.Interfaces;
using ProductApi.Validations;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);



#region 🔹 Configuration

builder.Services.Configure<JwtSettings>(
    builder.Configuration.GetSection("JwtSettings"));

#endregion

#region 🔹 Database (EF Core + SQL Server)

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region 🔹 Dependency Injection (Services)

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IFranchiseService, FranchiseService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();


builder.Services.AddScoped<JwtTokenGenerator>();

#endregion

#region 🔹 Authentication (JWT)

var jwtSettings = builder.Configuration
    .GetSection("JwtSettings")
    .Get<JwtSettings>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings.Secret))
    };
});

#endregion

#region 🔹 Authorization

builder.Services.AddAuthorization();

#endregion

#region 🔹 Controllers

builder.Services.AddControllers();

#endregion

#region 🔹 Swagger (JWT Enabled)

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PMS API",
        Version = "v1",
        Description = "Product Management System API"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token as: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

#endregion

#region 🔹 CORS (Frontend Access)

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

#endregion

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddValidatorsFromAssembly(typeof(UserValidator).Assembly);

var app = builder.Build();


#region 🔹 Middleware Pipeline

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.Migrate();

    // Seed Roles
    if (!context.Roles.Any())
    {
        context.Roles.AddRange(
            new Role { Name = "Admin" },
            new Role { Name = "Manager" },
            new Role { Name = "FranchiseUser" }
        );
        context.SaveChanges();
    }

    // Seed Admin User
    if (!context.Users.Any())
    {
        var adminRole = context.Roles.First(r => r.Name == "Admin");

        context.Users.Add(new User
        {
            Username="Admin",
            Email="admin@gmail.com",
            PasswordHash = PasswordHasher.Hash("Admin@123"),
            RoleId = adminRole.Id
        });

        context.SaveChanges();
    }
}

#endregion

app.Run();

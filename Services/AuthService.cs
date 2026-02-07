using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Auth;
using ProductApi.Security;
using ProductApi.Services.Interfaces;
using ProductApi.Security;

namespace ProductApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtTokenGenerator _jwt;

        public AuthService(AppDbContext context, JwtTokenGenerator jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !PasswordHasher.Verify(dto.Password, user.PasswordHash))
                return null;

            return _jwt.GenerateToken(user);
        }
    }
}

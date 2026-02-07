using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<UserFranchise> UserFranchises { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFranchise>()
                .HasKey(uf => new { uf.UserId, uf.FranchiseId });

            modelBuilder.Entity<UserFranchise>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.UserFranchises)
                .HasForeignKey(uf => uf.UserId);

            modelBuilder.Entity<UserFranchise>()
                .HasOne(uf => uf.Franchise)
                .WithMany(f => f.UserFranchises)
                .HasForeignKey(uf => uf.FranchiseId);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany(sc => sc.Products)
                .HasForeignKey(p => p.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<SubCategory>()
                .HasIndex(sc => new { sc.Name, sc.CategoryId })
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => new { p.Name, p.CategoryId, p.SubCategoryId })
                .IsUnique();

            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductCode)
                .IsUnique();

        }
    }
}

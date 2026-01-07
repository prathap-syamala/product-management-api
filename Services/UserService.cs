using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Users;
using ProductApi.Models;
using ProductApi.Services.Interfaces;
using ProductApi.Security;

namespace ProductApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            return await _context.Users
                .Include(u => u.Role)
                .Include(u => u.UserFranchises)
                    .ThenInclude(uf => uf.Franchise)
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role.Name,
                    Franchises = u.UserFranchises
                        .Select(f => f.Franchise.FranchiseName)
                        .ToList()
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = PasswordHasher.Hash(dto.Password),
                RoleId = dto.RoleId
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            foreach (var franchiseId in dto.FranchiseIds)
            {
                _context.UserFranchises.Add(new UserFranchise
                {
                    UserId = user.Id,
                    FranchiseId = franchiseId
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}

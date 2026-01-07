using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Franchises;
using ProductApi.Models;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
    public class FranchiseService : IFranchiseService
    {
        private readonly AppDbContext _context;

        public FranchiseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<FranchiseResponseDto>> GetAllAsync()
        {
            return await _context.Franchises
                .Select(f => new FranchiseResponseDto
                {
                    Id = f.Id,
                    FranchiseName = f.FranchiseName,
                    Location = f.Location,
                    TotalStaff = f.TotalStaff,
                    Email = f.Email,
                    Phone = f.Phone,
                    UserCount = f.UserFranchises != null
                        ? f.UserFranchises.Count
                        : 0
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateFranchiseDto dto)
        {
            // Business validation (important)
            bool alreadyExists = await _context.Franchises.AnyAsync(f =>
                f.Email == dto.Email || f.Phone == dto.Phone);

            if (alreadyExists)
            {
                throw new Exception("Franchise with the same email or phone already exists");
            }

            var franchise = new Franchise
            {
                FranchiseName = dto.FranchiseName,
                Location = dto.Location,
                TotalStaff = dto.TotalStaff,
                Email = dto.Email,
                Phone = dto.Phone
            };

            _context.Franchises.Add(franchise);
            await _context.SaveChangesAsync();
        }
    }
}

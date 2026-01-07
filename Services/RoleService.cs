using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Role;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<RoleResponseDto>> GetAllAsync()
        {
            return await _context.Roles
                .Select(r => new RoleResponseDto
                {
                    Id = r.Id,
                    Name = r.Name
                })
                .ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.Categories;
using ProductApi.Models;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryResponseDto>> GetAllAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    ProductCount = c.Products.Count
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateCategoryDto dto)
        {
            _context.Categories.Add(new Category { Name = dto.Name });
            await _context.SaveChangesAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.DTOs.SubCategory;
using ProductApi.Models;
using ProductApi.Services.Interfaces;

namespace ProductApi.Services
{
   public class SubCategoryService:ISubCategoryService
   {
        private readonly AppDbContext _context;

        public SubCategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubCategoryResponseDto>> GetAllAsync()
        {
            return await _context.SubCategories
                .Include(sc => sc.Category)
                .Select(sc => new SubCategoryResponseDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CategoryId = sc.CategoryId,
                    CategoryName = sc.Category.Name
                })
                .ToListAsync();
        }

        public async Task<List<SubCategoryResponseDto>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.SubCategories
                .Where(sc => sc.CategoryId == categoryId)
                .Select(sc => new SubCategoryResponseDto
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    CategoryId = sc.CategoryId
                })
                .ToListAsync();
        }

        public async Task CreateAsync(CreateSubCategoryDto dto)
        {
            var name = dto.Name.Trim();

            var exists = await _context.SubCategories.AnyAsync(sc =>
                sc.CategoryId == dto.CategoryId &&
                sc.Name.ToLower() == name.ToLower());

            if (exists)
                throw new InvalidOperationException(
                    "Sub-category already exists in this category");

            var subCategory = new SubCategory
            {
                Name = name,
                CategoryId = dto.CategoryId
            };

            _context.SubCategories.Add(subCategory);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(int id, CreateSubCategoryDto dto)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
                throw new KeyNotFoundException("SubCategory not found");

            subCategory.Name = dto.Name;
            subCategory.CategoryId = dto.CategoryId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var subCategory = await _context.SubCategories.FindAsync(id);
            if (subCategory == null)
                throw new KeyNotFoundException("SubCategory not found");

            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
        }
    }
}

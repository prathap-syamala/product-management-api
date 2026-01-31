using ProductApi.DTOs.Categories;
using ProductApi.DTOs.Category;

namespace ProductApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllAsync();
        Task CreateAsync(CreateCategoryDto dto);
        Task UpdateAsync(int id, UpdateCategoryDto dto);
    }
}

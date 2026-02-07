using ProductApi.DTOs.Categories;

namespace ProductApi.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryResponseDto>> GetAllAsync();

        Task<CategoryResponseDto?> GetByIdAsync(int id);   // ✅ ADD

        Task<CategoryResponseDto> CreateAsync(CreateCategoryDto dto);

        Task UpdateAsync(int id, CreateCategoryDto dto);

        Task DeleteAsync(int id);                          // ✅ ADD
    }
}

using ProductApi.DTOs.SubCategory;

namespace ProductApi.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task<List<SubCategoryResponseDto>> GetAllAsync();
        Task<List<SubCategoryResponseDto>> GetByCategoryIdAsync(int categoryId);
        Task CreateAsync(CreateSubCategoryDto dto);
        Task UpdateAsync(int id, CreateSubCategoryDto dto);
        Task DeleteAsync(int id);
    }
}

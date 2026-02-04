using ProductApi.DTOs.Products;
using ProductApi.Models;

namespace ProductApi.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductResponseDto>> GetAllAsync();
        Task CreateAsync(CreateProductDto dto);
        Task UpdateAsync(int id, CreateProductDto dto);
        Task<Product?> GetProductByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}

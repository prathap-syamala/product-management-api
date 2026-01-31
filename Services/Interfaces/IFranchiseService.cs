using ProductApi.DTOs.Franchise;
using ProductApi.DTOs.Franchises;

namespace ProductApi.Services.Interfaces
{
    public interface IFranchiseService
    {
        Task<List<FranchiseResponseDto>> GetAllAsync();
        Task CreateAsync(CreateFranchiseDto dto);
        Task UpdateAsync(int id, CreateFranchiseDto dto);
        Task DeleteAsync(int id);
        Task<FranchiseResponseDto> GetByIdAsync(int id);
    }
}

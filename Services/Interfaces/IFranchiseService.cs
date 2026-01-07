using ProductApi.DTOs.Franchises;

namespace ProductApi.Services.Interfaces
{
    public interface IFranchiseService
    {
        Task<List<FranchiseResponseDto>> GetAllAsync();
        Task CreateAsync(CreateFranchiseDto dto);
        
    }
}

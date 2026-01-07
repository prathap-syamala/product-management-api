using ProductApi.DTOs.Role;

namespace ProductApi.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleResponseDto>> GetAllAsync();
    }
}

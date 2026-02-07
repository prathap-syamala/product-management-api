using ProductApi.DTOs.User;

namespace ProductApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllAsync();
        Task CreateAsync(CreateUserDto dto);
        Task DeleteAsync(int id);
        Task<UserResponseDto?> GetByIdAsync(int id);
    }
}

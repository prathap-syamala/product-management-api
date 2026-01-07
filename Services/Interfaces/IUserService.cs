using ProductApi.DTOs.Users;

namespace ProductApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAllAsync();
        Task CreateAsync(CreateUserDto dto);
    }
}

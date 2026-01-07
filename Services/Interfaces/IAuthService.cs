using ProductApi.DTOs.Auth;

namespace ProductApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);
    }
}

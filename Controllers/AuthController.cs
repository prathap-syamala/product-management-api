using Microsoft.AspNetCore.Mvc;
using ProductApi.DTOs.Auth;
using ProductApi.Services.Interfaces;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var response = await _authService.LoginAsync(dto);
            if (response == null)
                return Unauthorized("Invalid credentials");

            return Ok(response);
        }
    }
}

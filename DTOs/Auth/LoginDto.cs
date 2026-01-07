using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}

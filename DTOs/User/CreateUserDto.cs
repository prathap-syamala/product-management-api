using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Users
{
    public class CreateUserDto
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public int RoleId { get; set; }

        public List<int> FranchiseIds { get; set; } = new();
    }
}

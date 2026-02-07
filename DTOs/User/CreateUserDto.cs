using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.User
{
    public class CreateUserDto
    {

        public string Username { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }

        public List<int> FranchiseIds { get; set; } = new();
    }
}

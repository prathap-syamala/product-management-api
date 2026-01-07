using ProductApi.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<UserFranchise> UserFranchises { get; set; }
    }
}

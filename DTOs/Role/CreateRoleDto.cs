using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Roles
{
    public class CreateRoleDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

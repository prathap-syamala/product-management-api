using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

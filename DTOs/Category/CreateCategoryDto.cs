using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Categories
{
    public class CreateCategoryDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

    }
}

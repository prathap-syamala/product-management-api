using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Products
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 999999)]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}

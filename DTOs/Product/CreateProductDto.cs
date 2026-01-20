using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Products
{
    public class CreateProductDto
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string Manufacturer { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(500)]
        public string ImageUrl { get; set; }

        [Required]
        [Range(0.01, 999999)]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}

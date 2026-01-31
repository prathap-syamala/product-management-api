using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product code is required")]
        [MaxLength(50)]
        public string ProductCode { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        [MaxLength(100)]
        public string Manufacturer { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(500)]
        [Url(ErrorMessage = "Invalid image URL")]
        public string ImageUrl { get; set; }

        [Required]
        [Range(0.01, 999999)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs.Products
{
    public class CreateProductDto
    {

        public string Name { get; set; }

        public string ProductCode { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

    }
}

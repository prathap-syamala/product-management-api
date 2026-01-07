namespace ProductApi.DTOs.Products
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsDeleteRequested { get; set; }
        public bool IsDeleted { get; set; }

    }
}

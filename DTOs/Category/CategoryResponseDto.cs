namespace ProductApi.DTOs.Categories
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductCount { get; set; }
        public bool IsDeleteRequested { get; set; }
        public bool IsDeleted { get; set; }

    }
}

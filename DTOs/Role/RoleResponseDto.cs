namespace ProductApi.DTOs.Role
{
    public class RoleResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleteRequested { get; set; }
        public bool IsDeleted { get; set; }

    }
}

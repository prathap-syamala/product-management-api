namespace ProductApi.DTOs.Users
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public List<string> Franchises { get; set; }
        public bool IsDeleteRequested { get; set; }
        public bool IsDeleted { get; set; }

    }
}

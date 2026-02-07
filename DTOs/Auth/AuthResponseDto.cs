namespace ProductApi.DTOs.Auth
{
    public class AuthResponseDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}

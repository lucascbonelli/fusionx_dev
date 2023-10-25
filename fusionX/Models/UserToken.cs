namespace EvenTech.Models
{
    public class UserToken
    {
        public uint UserId { get; set; }
        public User? User { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }
    }
}

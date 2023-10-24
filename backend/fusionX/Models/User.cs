namespace hackweek_backend.Models
{
    public class User
    {
        public uint Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public string PasswordHash { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime LastAccess { get; set; }
        public DateTime? VerificationDate { get; set; }
        public string Role { get; set; } = string.Empty;
        public byte[]? Image { get; set; }

        public ICollection<UserTag>? Tags { get; set; }
    }
}

using hackweek_backend.Models;

namespace hackweek_backend.Dtos
{
    public class UserDto
    {
        public uint Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Verified { get; set; }
        public string Role { get; set; } = string.Empty;

        public UserDto() { }

        public UserDto(User? user)
        {
            if (user != null)
            {
                Id = user.Id;
                Email = user.Email;
                IsEmailConfirmed = user.IsEmailConfirmed;
                Name = user.Name;
                Verified = (user.VerificationDate != null);
                Role = user.Role;
            }
        }
    }
}
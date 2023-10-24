using hackweek_backend.Models;

namespace hackweek_backend.Dtos
{
    public class UserTokenDto
    {
        public uint UserId { get; set; }
        public UserDto? User { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpirationDate { get; set; }

        public UserTokenDto(UserToken model)
        {
            UserId = model.UserId;
            User = (model.User == null) ? null : new UserDto(model.User);
            Email = model.Email;
            Token = model.Token;
            ExpirationDate = model.ExpirationDate;
        }
    }
}

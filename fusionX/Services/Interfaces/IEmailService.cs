using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(string email, string url);
        Task<UserToken> FindToken(string token);
        Task ConfirmEmail(string token, string password);
    }
}
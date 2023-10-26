using EvenTech.Models;

namespace EvenTech.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(string email);
        Task<UserToken> FindToken(string token);
        Task ConfirmEmail(string token, string password);
    }
}
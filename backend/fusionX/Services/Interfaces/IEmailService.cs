using hackweek_backend.dtos;
using MimeKit;

namespace hackweek_backend.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailConfirmation(string email, string url);

        Task<bool> GetEmailConfirmed(uint idUser);
    }
}
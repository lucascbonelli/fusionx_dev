namespace hackweek_backend.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmail(string email, string url);
        Task ConfirmEmail(string token);
    }
}
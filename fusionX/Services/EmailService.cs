using EvenTech.Data;
using EvenTech.Models;
using EvenTech.Services.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace EvenTech.Services
{
    public class EmailService : IEmailService
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly IUserTokenService _userTokenService;

        public EmailService(DataContext context, IConfiguration config, IUserTokenService userTokenService)
        {
            _context = context;
            _config = config;
            _userTokenService = userTokenService;
        }

        public async Task SendConfirmationEmail(string email)
        {
            var userToken = await _userTokenService.GenerateUserToken(email);
            if (userToken.User == null) throw new Exception("Usu�rio n�o encontrado!");

            TextPart body;
            if (userToken.User.IsEmailConfirmed)
            {
                body = new TextPart(TextFormat.Html) { Text = $"{userToken.User.Name},<br>Para recuperar sua senha do sistema EvenTech utilize a chave abaixo na aplica��o:<br><br>{userToken.Token}<br><br>A chave expira em {_config["Email:MinsExpire"]} minutos, ap�s isto ser� necess�rio solicitar a senha novamente." };
            }
            else
            {
                body = new TextPart(TextFormat.Html) { Text = $"{userToken.User.Name},<br>Para confirmar o seu e-mail junto ao sistema EvenTech utilize a chave abaixo na aplica��o:<br><br>{userToken.Token}<br><br>A chave expira em {_config["Email:MinsExpire"]} minutos, ap�s isto ser� necess�rio solicitar uma nova confirma��o." };
            }

            InternalSendEmail(email, "Confirma��o de e-mail", body);
        }

        public async Task<UserToken> FindToken(string token)
        {
            var userToken = await _context.UserTokens.Include(ut => ut.User).FirstOrDefaultAsync(u => u.Token == token) ?? throw new Exception("Token n�o encontrado!");
            if (DateTime.Now > userToken.ExpirationDate) throw new Exception("Link de acesso expirou!");
            return userToken;
        }

        public async Task ConfirmEmail(string token, string password)
        {
            var userToken = await FindToken(token);

            if (userToken.User != null)
            {
                userToken.User.IsEmailConfirmed = true;
                userToken.User.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

                _context.Entry(userToken.User).State = EntityState.Modified;
            }
            _context.UserTokens.Remove(userToken);
            await _context.SaveChangesAsync();
        }

        private void InternalSendEmail(string emailTo, string subject, TextPart body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_config["Email:UserName"], _config["Email:Address"]));
            message.To.Add(MailboxAddress.Parse(emailTo));
            message.Subject = subject;
            message.Body = body;

            using var smtp = new SmtpClient();
            smtp.Connect(_config["Email:Host"], int.Parse(_config["Email:Port"] ?? string.Empty), SecureSocketOptions.StartTls);
            try
            {
                smtp.Authenticate(_config["Email:Address"], _config["Email:Password"]);
                smtp.Send(message);
            }
            finally
            {
                smtp.Disconnect(true);
            }
        }
    }
}
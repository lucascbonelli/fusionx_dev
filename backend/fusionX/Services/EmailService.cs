using hackweek_backend.Services.Interfaces;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace hackweek_backend.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly IUserTokenService _userTokenService;

        public EmailService(IConfiguration config, IUserTokenService userTokenService)
        {
            _config = config;
            _userTokenService = userTokenService;
        }

        public async Task SendConfirmationEmail(string email, string url)
        {
            var userToken = await _userTokenService.GenerateUserToken(email);
            url = url.Replace("{token}", userToken.Token);

            var body = new TextPart(TextFormat.Html) { Text = $"{userToken.User?.Name},<br>Para confirmar o seu e-mail junto ao sistema FusionX <a href={url}>clique aqui</a> ou acesse o link abaixo:<br><br>{url}<br><br>O link expira em {_config["Email:MinsExpire"]} minutos, após isto será necessário solicitar uma nova confirmação." };

            InternalSendEmail(email, "Confirmação de e-mail", body);
        }

        public async Task ConfirmEmail(string token)
        {
            var userToken = await _userTokenService.GetUserToken(token) ?? throw new Exception("Token não encontrado!");
            if (userToken.ExpirationDate < DateTime.Now) throw new Exception("Token expirou!");


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
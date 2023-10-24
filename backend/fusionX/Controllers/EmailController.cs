using hackweek_backend.Dtos;
using hackweek_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hackweek_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send/{email}")]
        [AllowAnonymous]
        public async Task<ActionResult> SendConfirmationEmail(string email, [FromQuery] string url)
        {
            try
            {
                await _emailService.SendConfirmationEmail(email, url);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("confirm/{token}")]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string token)
        {
            try
            {
                await _emailService.ConfirmEmail(token);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

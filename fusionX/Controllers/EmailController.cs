using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
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
        public async Task<ActionResult> SendConfirmationEmail(string email)
        {
            try
            {
                await _emailService.SendConfirmationEmail(email);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("token/{token}")]
        [AllowAnonymous]
        public async Task<ActionResult> FindToken(string token)
        {
            try
            {
                await _emailService.FindToken(token);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("token/{token}/confirm")]
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string token, [FromBody] string password)
        {
            try
            {
                await _emailService.ConfirmEmail(token, password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

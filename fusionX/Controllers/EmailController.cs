using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _service;

        public EmailController(IEmailService service)
        {
            _service = service;
        }

        [HttpPost("send/{email}")]
        [AllowAnonymous]
        public async Task<ActionResult> SendConfirmationEmail(string email)
        {
            try
            {
                await _service.SendConfirmationEmail(email);
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
                await _service.FindToken(token);
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
                await _service.ConfirmEmail(token, password);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

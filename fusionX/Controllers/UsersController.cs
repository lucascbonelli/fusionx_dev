using EvenTech.Dtos;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IAuthService _auth;

        public UsersController(IUserService service, IAuthService auth)
        {
            _service = service;
            _auth = auth;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto?>> GetUserById(uint id)
        {
            var user = await _service.GetUserById(id);
            if (user == null) return NotFound("Usu�rio n�o encontrado!");

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser(UserDtoInsert request)
        {
            try
            {
                await _service.CreateUser(request);
                return Ok("Usu�rio adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteUser(uint id)
        {
            try
            {
                if (!_auth.HasAccessToUser(HttpContext, id)) return Unauthorized($"Acesso ao usu�rio {id} foi negado.");

                await _service.DeleteUser(id);
                return Ok("Usu�rio exclu�do com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> UpdateUser(uint id, UserDtoUpdate request)
        {
            try
            {
                if (!_auth.HasAccessToUser(HttpContext, id)) return Unauthorized($"Acesso ao usu�rio {id} foi negado.");

                await _service.UpdateUser(id, request);
                return Ok("Usu�rio atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
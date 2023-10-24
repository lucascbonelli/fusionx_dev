using hackweek_backend.dtos;
using hackweek_backend.Models;
using hackweek_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hackweek_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<UserDto?>> GetUserById(uint id)
        {
            var user = await _service.GetUserById(id);
            if (user == null) return NotFound("Usuário não encontrado!");

            return Ok(user);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> CreateUser(UserDtoInsert request)
        {
            try
            {
                await _service.CreateUser(request);
                return Ok("Usuário adicionado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> DeleteUser(uint id)
        {
            try
            {
                await _service.DeleteUser(id);
                return Ok("Usuário excluído com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> UpdateUser(uint id, UserDtoUpdate request)
        {
            try
            {
                await _service.UpdateUser(id, request);
                return Ok("Usuário atualizado com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("role/{role}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersEventByRole(string role)
        {
            return Ok(await _service.GetUsersEventByRole(role));
        }

        [HttpGet("{id}/redefine")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<string>> RedefinePassword(uint id)
        {
            try
            {
                return Ok(await _service.RedefinePassword(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
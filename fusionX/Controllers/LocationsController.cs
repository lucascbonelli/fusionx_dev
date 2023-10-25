using hackweek_backend.dtos;
using hackweek_backend.Models;
using hackweek_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hackweek_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _service;

        public LocationsController(ILocationService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<LocationDto?>> GetLocationById(uint id)
        {
            var location = await _service.GetLocationById(id);
            if (location == null)
            {
                return NotFound("Localização não encontrada!");
            }

            return Ok(location);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult> CreateLocation(LocationDtoInsert request)
        {
            try
            {
                await _service.CreateLocation(request);
                return Ok("Localização adicionada com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //put

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult> DeleteLocation(uint id)
        {
            try
            {
                await _service.DeleteLocation(id);
                return Ok("Localização removida com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //userid

        //location id

        //confirmed id


    }
}

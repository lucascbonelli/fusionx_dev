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

        [HttpGet("id")]
        //[Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<LocationDto?>> GetLocationById(uint id)
        {
            var location = await _service.GetLocationById(id);
            if (location == null)
            {
                return NotFound("Localização não encontrada!");
            }

            return Ok(location);
        }

        //post

        //put

        [HttpDelete("{id}")]
        //[Authorize(Roles = UserRoles.Company)]
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

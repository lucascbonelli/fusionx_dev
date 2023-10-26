using EvenTech.dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
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

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult> UpdateLocation(uint id, LocationDtoUpdate request)
        {
            try
            {
                await _service.UpdateLocation(id, request);
                return Ok("Localização atualizada com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

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

    }
}

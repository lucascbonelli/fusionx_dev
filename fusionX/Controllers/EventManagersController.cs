using EvenTech.dtos;
using EvenTech.Models.Constraints;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventManagersController : ControllerBase
    {
        private readonly IEventManagerService _service;

        public EventManagersController(IEventManagerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var eventManagers = await _service.GetAllAsync();
            if(eventManagers is null || !eventManagers.Any())
            {
                return NotFound("No one was found!");
            }
            return Ok(eventManagers);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(uint id)
        {
            try
            {
                var eventManager = await _service.GetByIdAsync(id);
                if(eventManager == null) return NotFound();
                return Ok(eventManager);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = UserConstraints.Roles.Company)]
        public async Task<IActionResult> Create(EventManagerDtoCreate eventManagerDtoCreate)
        {
            try
            {
                var createdEventManager = await _service.CreateAsync(eventManagerDtoCreate);
                return CreatedAtAction(nameof(GetById), new { id = createdEventManager.Id }, createdEventManager);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserConstraints.Roles.Admin + "," + UserConstraints.Roles.Company)]
        public async Task<IActionResult> Delete(uint id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

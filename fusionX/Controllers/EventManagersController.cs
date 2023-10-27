using EvenTech.Models;
using EvenTech.Services.Interfaces;
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
        public async Task<IActionResult> GetAll()
        {
            var eventManagers = await _service.GetAllAsync();
            return Ok(eventManagers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var eventManager = await _service.GetByIdAsync(id);
            if(eventManager == null) return NotFound();
            return Ok(eventManager);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventManager eventManager)
        {
            var createdEventManager = await _service.CreateAsync(eventManager);
            return CreatedAtAction(nameof(GetById), new { id = createdEventManager.Id }, createdEventManager);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EventManager eventManager)
        {
            if(id != eventManager.Id) return BadRequest();
            await _service.UpdateAsync(eventManager);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

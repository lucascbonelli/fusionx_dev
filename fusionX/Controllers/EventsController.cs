using EvenTech.Dtos;
using EvenTech.Models;
using EvenTech.Models.Constraints;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class EventsController : ControllerBase
    {

        private readonly IEventService _service;

        public EventsController(IEventService eventService)
        {
            _service = eventService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllEvents()
        {
            return Ok(await _service.GetAllEventsAsync());
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetEventById(uint id)
        {
            var eventItem = await _service.GetEventByIdAsync(id);
            if (eventItem == null)
                return NotFound();
            return Ok(eventItem);
        }

        [HttpPost]
        [Authorize(Roles = UserConstraints.Roles.Company)]
        public async Task<IActionResult> CreateEvent(EventDtoCreate eventItem)
        {
            var createdEvent = await _service.CreateEventAsync(eventItem);
            return CreatedAtAction(nameof(GetEventById),new { id = createdEvent.Id },createdEvent);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserConstraints.Roles.Company)]
        public async Task<IActionResult> UpdateEvent(uint id,EventDtoUpdate eventItem)
        {
            if (id != eventItem.Id)
                return BadRequest();

            var existingEvent = await _service.GetEventByIdAsync(id);
            if (existingEvent == null)
                return NotFound();

            var claimValue = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(claimValue))
                return BadRequest("User identifier not found.");

            if (!uint.TryParse(claimValue,out var currentUserId))
                return BadRequest("Invalid user identifier format.");

            if (existingEvent.UserId != currentUserId)
                return Forbid("You don't have permission to update this event.");

            await _service.UpdateEventAsync(id,eventItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserConstraints.Roles.Admin + "," + UserConstraints.Roles.Company)]
        public async Task<IActionResult> DeleteEvent(uint id)
        {
            await _service.DeleteEventAsync(id);
            return NoContent();
        }
    }
}

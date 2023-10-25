﻿using EvenTech.Models;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private readonly IEventService _service;

        public EventsController(IEventService eventService)
        {
            _service = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            return Ok(await _service.GetAllEventsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(uint id)
        {
            var eventItem = await _service.GetEventByIdAsync(id);
            if (eventItem == null)
                return NotFound();
            return Ok(eventItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event eventItem)
        {
            var createdEvent = await _service.CreateEventAsync(eventItem);
            return CreatedAtAction(nameof(GetEventById),new { id = createdEvent.Id },createdEvent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(uint id,Event eventItem)
        {
            if (id != eventItem.Id)
                return BadRequest();

            await _service.UpdateEventAsync(eventItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(uint id)
        {
            await _service.DeleteEventAsync(id);
            return NoContent();
        }
    }
}

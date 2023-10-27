using EvenTech.Dtos;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("api/eventTags")]
    [ApiController]
    public class EventTagController : ControllerBase
    {
        private readonly IEventTagService _service;

        public EventTagController(IEventTagService service)
        {
            _service = service;
        }

        [HttpGet("{tagId}/{eventId}")]
        public async Task<ActionResult<EventTagDto>> GetEventTagById(uint tagId, uint eventId)
        {
            var eventTag = await _service.GetEventTagById(tagId, eventId);
            if (eventTag == null)
            {
                return NotFound();
            }
            return Ok(eventTag);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEventTag([FromBody] EventTagDto request)
        {
            await _service.CreateEventTag(request);
            return CreatedAtAction("CreateEventTag", new { tagId = request.TagId, eventId = request.EventId }, request);
        }

        [HttpDelete("{tagId}/{eventId}")]
        public async Task<ActionResult> DeleteEventTag(uint tagId, uint eventId)
        {
            try
            {
                await _service.DeleteEventTag(tagId, eventId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("byEvent/{eventId}")]
        public async Task<ActionResult<IEnumerable<EventTagDto>>> GetEventTagsByEventId(uint eventId)
        {
            var eventTags = await _service.GetEventTagsByEventId(eventId);
            return Ok(eventTags);
        }

        [HttpGet("byTag/{tagId}")]
        public async Task<ActionResult<IEnumerable<EventTagDto>>> GetEventsByTagId(uint tagId)
        {
            var eventTags = await _service.GetEventsByTagId(tagId);
            return Ok(eventTags);
        }

    }
}




using EvenTech.Dtos;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _service;

        public SessionsController(ISessionService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetSessionDayById(uint id)
        {
            var session = await _service.GetSessionDayById(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSession([FromBody] SessionDtoInsert request)
        {
            var session = await _service.CreateSession(request);
            return CreatedAtAction("CreateSession", new { id = session.Id }, session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(uint id, [FromBody] SessionDtoUpdate request)
        {
            try
            {
                await _service.UpdateSession(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSession(uint id)
        {
            try
            {
                await _service.DeleteSession(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("byEvent/{eventId}")]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetSessionByEventId(uint eventId)
        {
            var sessions = await _service.GetSessionByEventId(eventId);
            return Ok(sessions);
        }

        [HttpGet("{id}/availableCapacity")]
        public async Task<ActionResult<int>> GetAvailableCapacity(uint id)
        {
            try
            {
                var availableCapacity = await _service.GetAvailableCapacity(id);
                return Ok(availableCapacity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

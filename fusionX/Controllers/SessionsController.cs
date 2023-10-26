using EvenTech.Dtos;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvenTech.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SessionDto>> GetSessionDayById(uint id)
        {
            var session = await _sessionService.GetSessionDayById(id);
            if (session == null)
            {
                return NotFound();
            }
            return Ok(session);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSession([FromBody] SessionDto request)
        {
            await _sessionService.CreateSession(request);
            return CreatedAtAction("CreateSession", new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSession(uint id, [FromBody] SessionDtoUpdate request)
        {
            try
            {
                await _sessionService.UpdateSession(id, request);
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
                await _sessionService.DeleteSession(id);
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
            var sessions = await _sessionService.GetSessionByEventId(eventId);
            return Ok(sessions);
        }

        [HttpGet("{id}/availableCapacity")]
        public async Task<ActionResult<int>> GetAvailableCapacity(uint id)
        {
            try
            {
                var availableCapacity = await _sessionService.GetAvailableCapacity(id);
                return Ok(availableCapacity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

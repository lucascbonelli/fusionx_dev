using EvenTech.Dtos;
using EvenTech.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EvenTech.Controllers
{
    [Route("api/lectures")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _service;

        public LectureController(ILectureService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LectureDto>> GetLectureById(uint id)
        {
            var lecture = await _service.GetLectureById(id);
            if (lecture == null)
            {
                return NotFound();
            }
            return Ok(lecture);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLecture([FromBody] LectureDto request)
        {
            await _service.CreateLecture(request);
            return CreatedAtAction("CreateLecture", new { id = request.Id }, request);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLecture(uint id, [FromBody] LectureDtoUpdate request)
        {
            try
            {
                await _service.UpdateLecture(id, request);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLecture(uint id)
        {
            try
            {
                await _service.DeleteLecture(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("bySession/{sessionId}")]
        public async Task<ActionResult<IEnumerable<LectureDto>>> GetLecturesBySessionId(uint sessionId)
        {
            var lectures = await _service.GetLecturesBySessionId(sessionId);
            return Ok(lectures);
        }

        [HttpGet("byEvent/{eventId}")]
        public async Task<ActionResult<IEnumerable<LectureDto>>> GetLecturesByEventId(uint eventId)
        {
            var lectures = await _service.GetLecturesByEventId(eventId);
            return Ok(lectures);
        }
    }
}

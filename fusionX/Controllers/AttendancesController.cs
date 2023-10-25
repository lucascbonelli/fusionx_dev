using hackweek_backend.dtos;
using hackweek_backend.Models;
using hackweek_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hackweek_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _service;

        public AttendancesController(IAttendanceService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<AttendanceDto?>> GetAttendanceById(uint id)
        {
            var attendance = await _service.GetAttendanceById(id);
            if (attendance == null)
            {
                return NotFound("Inscrição não encontrada!");
            }

            return Ok(attendance);
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult> CreateAttendance(AttendanceDtoInsert request)
        {
            try
            {
                await _service.CreateAttendance(request);
                return Ok("Inscrição efetuada com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult> UpdateAttendance(uint id, AttendanceDtoUpdate request)
        {
            try
            {
                await _service.UpdateAttendance(id, request);
                return Ok("Status da inscrição atualizado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult> DeleteAttendance(uint id)
        {
            try
            {
                await _service.DeleteAttendance(id);
                return Ok("Inscrição removida com sucesso!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("user/{userId}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetAttendancesByUserId(uint userId)
        {
            var attendances = await _service.GetAttendancesByUserId(userId);
            return Ok(attendances);
        }

        [HttpGet("eventday/{eventDayId}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetAttendancesByEventDayId(uint eventDayId)
        {
            var attendances = await _service.GetAttendancesByEventDayId(eventDayId);
            return Ok(attendances);
        }

        [HttpGet("totalconfirmed/{eventId}")]
        [Authorize(Roles = UserRoles.Company)]
        public async Task<ActionResult<int>> GetTotalConfirmedAttendances(uint eventId)
        {
            var totalConfirmedAttendances = await _service.GetTotalConfirmedAttendances(eventId);
            return Ok(totalConfirmedAttendances);
        }
    }
}

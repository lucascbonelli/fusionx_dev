using hackweek_backend.dtos;
using hackweek_backend.Models;
using hackweek_backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hackweek_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
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
                return NotFound("Attendance not found!");
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
                return Ok("Attendance created successfully!");
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
                return Ok("Attendance updated successfully!");
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
                return Ok("Attendance deleted successfully!");
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

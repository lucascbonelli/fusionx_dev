using EvenTech.Data;
using EvenTech.dtos;
using EvenTech.Models;
using EvenTech.Models.Constraints;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly DataContext _context;

        public AttendanceService(DataContext context)
        {
            _context = context;
        }

        public async Task<AttendanceDto?> GetAttendanceById(uint id)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            return attendance != null ? new AttendanceDto(attendance) : null;
        }
        public async Task CreateAttendance(AttendanceDtoInsert request)
        {
            var attendanceModel = new Attendance
            {
                Status = request.Status,
                SessionId = request.SessionId,
                UserId = request.UserId
            };

            await _context.Attendances.AddAsync(attendanceModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAttendance(uint id, AttendanceDtoUpdate request)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
            {
                throw new Exception("Inscrição não encontrada!");
            }

            attendance.Status = request.Status;
            attendance.SessionId = request.SessionId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAttendance(uint id)
        {
            var attendance = await _context.Attendances.FindAsync(id);

            if (attendance == null)
            {
                throw new Exception("Inscrição não encontrada!");
            }

            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AttendanceDto>> GetAttendancesByUserId(uint userId)
        {
            var attendances = await _context.Attendances
                .Where(a => a.UserId == userId)
                .Select(a => new AttendanceDto(a))
                .ToListAsync();

            return attendances;
        }

        public async Task<IEnumerable<AttendanceDto>> GetAttendancesByEventDayId(uint eventDayId)
        {
            var attendances = await _context.Attendances
                .Where(a => a.SessionId == eventDayId)
                .Select(a => new AttendanceDto(a))
                .ToListAsync();

            return attendances;
        }

        public async Task<int> GetTotalConfirmedAttendances(uint eventId)
        {
            var totalConfirmedAttendances = await _context.Attendances
                .Where(a => a.SessionId == eventId && a.Status == FeedbackConstraints.Status.Confirmed)
                .CountAsync();

            return totalConfirmedAttendances;
        }
    }
}


using hackweek_backend.Data;
using hackweek_backend.dtos;
using hackweek_backend.Models;
using hackweek_backend.Services.Interfaces;

namespace hackweek_backend.Services
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
                LectureId = request.LectureId,
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
            attendance.LectureId = request.LectureId;

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
                .Where(a => a.LectureId == eventDayId)
                .Select(a => new AttendanceDto(a))
                .ToListAsync();

            return attendances;
        }

        public async Task<int> GetTotalConfirmedAttendances(uint eventId)
        {
            var totalConfirmedAttendances = await _context.Attendances
                .Where(a => a.LectureId == eventId && a.Status == "Confirmado")
                .CountAsync();

            return totalConfirmedAttendances;
        }
    }
}


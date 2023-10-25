using hackweek_backend.dtos;

namespace hackweek_backend.Services.Interfaces
{
    public interface IAttendanceService
    {
        Task<AttendanceDto?> GetAttendanceById(uint id);
        Task CreateAttendance(AttendanceDtoInsert request);
        Task UpdateAttendance(uint id, AttendanceDtoUpdate request);
        Task DeleteAttendance(uint id);

        Task<IEnumerable<AttendanceDto>> GetAttendancesByUserId(uint userId);
        Task<IEnumerable<AttendanceDto>> GetAttendancesByEventDayId(uint eventDayId);
        Task<int> GetTotalConfirmedAttendances(uint eventId);
    }
}

using EvenTech.Models;

namespace EvenTech.dtos
{
    public class AttendanceDto
    {
        public uint Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public uint SessionId { get; set; }
        public uint UserId { get; set; }

        public AttendanceDto(Attendance attendance)
        {
            Id = attendance.Id;
            Status = attendance.Status;
            SessionId = attendance.SessionId;
            UserId = attendance.UserId;
        }
    }
}

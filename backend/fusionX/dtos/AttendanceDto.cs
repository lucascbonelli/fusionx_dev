using hackweek_backend.Models;

namespace hackweek_backend.dtos
{
    public class AttendanceDto
    {
        public uint Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public uint LectureId { get; set; }
        public uint UserId { get; set; }

        public AttendanceDto(Attendance attendance)
        {
            Id = attendance.Id;
            Status = attendance.Status;
            LectureId = attendance.LectureId;
            UserId = attendance.UserId;
        }
    }
}

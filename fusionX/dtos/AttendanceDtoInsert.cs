namespace hackweek_backend.dtos
{
    public class AttendanceDtoInsert
    {
        public string Status { get; set; } = string.Empty;
        public uint LectureId { get; set; }
        public uint UserId { get; set; }
    }
}

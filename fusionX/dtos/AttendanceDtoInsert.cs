namespace EvenTech.dtos
{
    public class AttendanceDtoInsert
    {
        public string Status { get; set; } = string.Empty;
        public uint SessionId { get; set; }
        public uint UserId { get; set; }
    }
}

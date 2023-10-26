﻿namespace EvenTech.Models
{
    public class Attendance
    {
        public uint Id { get; set; }
        public string Status { get; set; } = string.Empty;

        public uint SessionId { get; set; }
        public Session? Session { get; set; }

        public uint UserId { get; set; }
        public User? User { get; set; }
    }
}

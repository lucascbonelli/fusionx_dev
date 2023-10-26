namespace EvenTech.Models
{
    public class UserTag
    {
        public uint TagId { get; set; }
        public Tag? Tag { get; set; }

        public uint UserId { get; set; }
        public User? User { get; set; }

        public int Occurrences { get; set; }
    }
}

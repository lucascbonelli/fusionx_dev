namespace hackweek_backend.Models
{
    public class Location
    {
        public uint Id { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Disctrict { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Complement { get; set; } = string.Empty;
    }
}

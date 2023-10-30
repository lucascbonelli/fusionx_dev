using EvenTech.Models;
namespace EvenTech.dtos
{
    public class LocationDto
    {
        public uint Id { get; set; }
        public string ZipCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Disctrict { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;

        public int Number { get; set; }
        public string Complement { get; set; } = string.Empty;

        public LocationDto(Location location)
        {
            Id = location.Id;
            ZipCode = location.ZipCode;
            State = location.State;
            City = location.City;
            Disctrict = location.Disctrict;
            Street = location.Street;
            Number = location.Number;
            Complement = location.Complement;
        }
    }
}

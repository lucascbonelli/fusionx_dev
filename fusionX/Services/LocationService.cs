using EvenTech.Data;
using EvenTech.dtos;
using EvenTech.Models;
using EvenTech.Services.Interfaces;

namespace EvenTech.Services
{
    public class LocationService : ILocationService
    {
        private readonly DataContext _context;

        public LocationService(DataContext context)
        {
            _context = context;
        }

        public async Task<LocationDto?> GetLocationById(uint id)
        {
            var location = await _context.Locations.FindAsync(id);

            return location != null ? new LocationDto(location) : null;
        }

        public async Task CreateLocation(LocationDtoInsert request)
        {
            var locationModel = new Location
            {
                ZipCode = request.ZipCode,
                State = request.State,
                City = request.City,
                Disctrict = request.Disctrict,
                Street = request.Street,
                Number = request.Number,
                Complement = request.Complement,
            };

            await _context.Locations.AddAsync(locationModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLocation(uint id, LocationDtoUpdate request)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                throw new Exception("Localização não encontrada!");
            }
            location.ZipCode = request.ZipCode;
            location.State = request.State;
            location.City = request.City;
            location.Disctrict = request.Disctrict;
            location.Street = request.Street;
            location.Number = request.Number;
            location.Complement = request.Complement;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLocation(uint id)
        {
            var location = await _context.Locations.FindAsync(id);

            if (location == null)
            {
                throw new Exception("Localização não encontrada!");
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();
        }

    }
}

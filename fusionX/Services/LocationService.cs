using hackweek_backend.Data;
using hackweek_backend.dtos;
using hackweek_backend.Services.Interfaces;

namespace hackweek_backend.Services
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

        //create

        //update

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

        //Locations by id

        //locations by user

        //locations by confirmed

    }
}

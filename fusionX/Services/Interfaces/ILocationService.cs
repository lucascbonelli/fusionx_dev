using EvenTech.dtos;

namespace EvenTech.Services.Interfaces
{
    public interface ILocationService
    {
        Task<LocationDto?> GetLocationById(uint id);
        Task CreateLocation(LocationDtoInsert request);
        Task UpdateLocation(uint id, LocationDtoUpdate request);
        Task DeleteLocation(uint id);

        Task<LocationDto?> GetLocationByZipCode(uint ZipCode);

    }
}

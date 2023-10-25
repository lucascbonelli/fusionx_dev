using hackweek_backend.dtos;

namespace hackweek_backend.Services.Interfaces
{
    public interface ILocationService
    {
        Task<LocationDto?> GetLocationById(uint id);
        Task CreateLocation(LocationDtoInsert request);
        Task UpdateLocation(uint id, LocationDtoUpdate request);
        Task DeleteLocation(uint id);

        //Task<IEnumerable<LocationDto>> GetLocationsByUserId(uint userId);
        //Task<IEnumerable<LocationDto>> GetLocationsByEventDayId(uint eventDayId);
        //Task<int> GetTotalConfirmedLocations(uint eventId);
    }
}

using FlightDocsSystem.DTO;
using FlightDocsSystem.Models;

namespace FlightDocsSystem.IServices
{
    public interface IFlightService
    {
        public Task<List<Flight>> getAllFlightAsync();

        public Task<Flight> getFlightAsync(int id);

        public Task<List<FlightConditionDTO>> GetFlightByConditionAsync(int flightId);

        public Task<FLightCountDTO> CountFileUploadAsync(int flightId);

        public Task<Flight> AddFlightAsync(FlightDTO model);

        public Task<Flight> UpdateFlightAsync(int id, FlightDTO model);

        public Task DeleteFlightAsync(int id);
    }
}

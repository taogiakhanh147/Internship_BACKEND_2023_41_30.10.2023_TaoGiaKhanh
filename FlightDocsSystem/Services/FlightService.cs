using FlightDocsSystem.DTO;
using FlightDocsSystem.IServices;
using FlightDocsSystem.Models;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FlightDocsSystem.Services
{
    public class FlightService : IFlightService
    {
        private readonly FlightDocsSystemContext _context;

        public FlightService(FlightDocsSystemContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> getAllFlightAsync()
        {
            var Flights = await _context.Flights.Include(f=>f.User).ToListAsync();
            return Flights;
        }

        public async Task<Flight> getFlightAsync(int id)
        {
            var flight = await _context.Flights.FindAsync(id);
            if (_context.Flights == null || flight == null)
            {
                throw new NotFoundException("ID does not exist");
            }
            return flight;
        }

        public async Task<List<FlightConditionDTO>> GetFlightByConditionAsync(int flightId)
        {
            var flight = await _context.Flights
                .Include(f => f.documents)
                .ThenInclude(d => d.documentTypes)
                .Include(f => f.User)
                .FirstOrDefaultAsync(f => f.FlightID == flightId);

            if (flight == null)
            {
                throw new NotFoundException("Flight not found.");
            }

            var documents = flight.documents.Select(d => new FlightConditionDTO
            {
                DocumentName = d.DocumentName,
                Type = d.documentTypes.DocumentTypeName,
                CreateDate = d.CreateDate ?? DateTime.MinValue,
                Creator = flight.User.UserName,
                LastVersion = d.Version ?? 0.0m
            }).ToList();
            return documents;
        }

        public async Task<FLightCountDTO> CountFileUploadAsync(int flightId)
        {
            var flight = await _context.Flights
                .Where(f => f.FlightID == flightId)
                .Select(f => new
                {
                    f.FlightID,
                    f.FlightNo,
                    SendFiles = _context.historyDocuments
                        .Include(hd => hd.Document)
                        .Count(hd => hd.Document.FlightID == flightId)
                })
                .FirstOrDefaultAsync();
            if (flight == null)
            {
                throw new NotFoundException("Flight not found.");
            }

            var countDocument = new FLightCountDTO
            {
                FlightID = flight.FlightID,
                FlightNO = flight.FlightNo,
                SendFiles = flight.SendFiles
            };

            return countDocument;
        }


        public async Task<Flight> AddFlightAsync(FlightDTO FlightDTO)
        {
            if (FlightDTO == null)
            {
                throw new NotFoundException("Please enter complete information");
            }

            var Flight = new Flight
            {
                FlightNo = FlightDTO.FlightNo,
                DepartureDate = FlightDTO.DepartureDate,
                ArrivalDate = FlightDTO.ArrivalDate,
                DepartureTime = FlightDTO.DepartureTime,
                ArrivalTime = FlightDTO.ArrivalTime,
                Route = FlightDTO.Route,
                Departure = FlightDTO.Departure,
                Arrival = FlightDTO.Arrival,
                UserCreateID = FlightDTO.UserCreateID
            };
            _context.Flights.Add(Flight);
            await _context.SaveChangesAsync();
            return Flight;
        }

        public async Task<Flight> UpdateFlightAsync(int id, FlightDTO model)
        {
            var existingFlight = await _context.Flights.FindAsync(id);
            if (existingFlight == null)
            {
                throw new NotFoundException("ID does not exist");
            }
            else
            {
                existingFlight.FlightNo = model.FlightNo;
                existingFlight.DepartureDate = model.DepartureDate;
                existingFlight.ArrivalDate = model.ArrivalDate;
                existingFlight.UpdateDate = DateTime.Now;
                existingFlight.DepartureTime = model.DepartureTime;
                existingFlight.ArrivalTime = model.ArrivalTime;
                existingFlight.Route = model.Route;
                existingFlight.Departure = model.Departure;
                existingFlight.Arrival = model.Arrival;
                existingFlight.UserCreateID = model.UserCreateID;
                _context.Flights.Update(existingFlight);
                await _context.SaveChangesAsync();
            }
            return existingFlight;
        }

        public async Task DeleteFlightAsync(int id)
        {
            var existingFlight = _context.Flights!.SingleOrDefault(b => b.FlightID == id);
            if (existingFlight != null)
            {
                _context.Flights.Remove(existingFlight);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("ID does not exist");
            }
        }
    }
}

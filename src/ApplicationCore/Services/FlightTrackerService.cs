using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class FlightTrackerService : IFlightTrackerService
    {
        private readonly IFlightTrackerRepository _flightRepository;
        private readonly IAsyncRepository<Aireport> _aireportRepository;

        public FlightTrackerService(IFlightTrackerRepository flightRepository,
            IAsyncRepository<Aireport> aireportRepository)
        {
            _flightRepository = flightRepository;
            _aireportRepository = aireportRepository;
        }

        public async Task<IReadOnlyList<Flight>> GetFlightsAsync()
        {
            return await _flightRepository.GetFlightsAsync();
        }

        public async Task<int> AddFlightAsync(string DepartureAireportName, string DestinationAireportName)
        {
            //Check flight unicity 
            if (await _flightRepository.GetFlightByAireportsName(DepartureAireportName, DestinationAireportName) != null)
            {
                throw new InvalidOperationException("This flight already exist !");
            }

            //TODO Check Aireport name unicity
            Aireport departureAirport = await _aireportRepository.AddAsync(new Aireport
            {
                Name = "CDG PARIS",
                Latitude = "48.8566101",
                Longitude = "2.3514992"
            });
            Aireport destinationAirport = await _aireportRepository.AddAsync(new Aireport
            {
                Name = "CMN CASABLANCA",
                Latitude = "33.5950627",
                Longitude = "-7.6187768"
            });

            var flight = await _flightRepository.AddAsync(new Flight
            {
                DepartureAireportId = departureAirport.Id,
                DestinationAireportId = destinationAirport.Id,
                DistenceBetweenAireports = 2000,
                RequiredFuel = 300

            });

            return flight.Id;
        }

        public Task UpdateFlightAsync(int flightId, string DepartureAireportName, string DestinationAireportName)
        {
            throw new NotImplementedException();
        }

    }
}

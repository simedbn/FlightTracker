using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IFlightTrackerService
    {
        Task<int> AddFlightAsync(string DepartureAireportName, string DestinationAireportName);

        Task UpdateFlightAsync(int flightId, string DepartureAireportName, string DestinationAireportName);

        Task<IReadOnlyList<Flight>> GetFlightsAsync();
    }
}

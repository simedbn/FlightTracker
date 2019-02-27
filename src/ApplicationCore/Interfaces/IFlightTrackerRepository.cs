using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IFlightTrackerRepository : IAsyncRepository<Flight>
    {
        Task<Flight> GetFlightByAireportsName(string DepartureAireport,string DestinationAireport);

        Task<IReadOnlyList<Flight>> GetFlightsAsync();
    }
}

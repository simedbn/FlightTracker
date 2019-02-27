using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class FlightTrackerRepository : EFRepository<Flight>, IFlightTrackerRepository
    {
        public FlightTrackerRepository(FlightTrackerContext dbContext) : base(dbContext)
        {
        }

        public async Task<Flight> GetFlightByAireportsName(string DepartureAireport, string DestinationAireport)
        {
            return await _dbContext
                  .Flights
                  .Include(f => f.DepartureAireport)
                  .Include(f => f.DestinationAireport)
                  .FirstOrDefaultAsync(f => f.DepartureAireport.Name.ToLower() == DepartureAireport.ToLower()
                                            &&
                                            f.DestinationAireport.Name.ToLower() == DestinationAireport.ToLower());
        }

        public async Task<IReadOnlyList<Flight>> GetFlightsAsync()
        {
            return await _dbContext.Flights
                              .Include(f => f.DepartureAireport)
                              .Include(f => f.DestinationAireport)
                              .ToListAsync();
        }
    }
}

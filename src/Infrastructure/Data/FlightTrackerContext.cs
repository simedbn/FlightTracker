using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class FlightTrackerContext : DbContext
    {
        public FlightTrackerContext(DbContextOptions<FlightTrackerContext> options) : base(options)
        {
        }

        public DbSet<Aireport> Aireports { get; set; }

        public DbSet<Flight> Flights { get; set; }
    }
}

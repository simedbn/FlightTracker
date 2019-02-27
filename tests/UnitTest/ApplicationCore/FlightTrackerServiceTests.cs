using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    public class FlightTrackerServiceTests
    {
        private static DbContextOptions<FlightTrackerContext> options;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            // Arrange
            options = new DbContextOptionsBuilder<FlightTrackerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;


        }

        [TestMethod]
        public void TestAddNewFlight()
        {
            using (var _applicationDbContext = new FlightTrackerContext(options))
            {
                _applicationDbContext.Database.EnsureDeleted();

                IFlightTrackerRepository flightRepository = new FlightTrackerRepository(_applicationDbContext);
                IAsyncRepository<Aireport> aireportRepository = new EFRepository<Aireport>(_applicationDbContext);

                IFlightTrackerService flightTrackerService = new FlightTrackerService(flightRepository, aireportRepository);
                // Act
                flightTrackerService.AddFlightAsync("CDG PARIS", "CMN CASABLANCA");
                var flight = _applicationDbContext.Flights.Include(p => p.DepartureAireport)
                    .Include(p => p.DestinationAireport)
                    .First();
                // Assert                
                Assert.IsNotNull(flight);
            };
        }

    }
}


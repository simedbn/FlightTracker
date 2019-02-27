using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Flight : EntityBase
    {

        public int DepartureAireportId { get; set; }

        public Aireport DepartureAireport { get; set; }

        public int DestinationAireportId { get; set; }

        public Aireport DestinationAireport { get; set; }

        public decimal DistenceBetweenAireports { get; set; }

        public decimal RequiredFuel { get; set; }

    }
}

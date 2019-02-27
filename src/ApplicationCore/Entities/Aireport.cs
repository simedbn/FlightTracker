using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Aireport : EntityBase
    {
        public string Name { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}

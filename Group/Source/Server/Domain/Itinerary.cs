using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Itinerary
    {
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        private IEnumerable<Shipment> Shipments;
        private IEnumerable<Leg> Legs;

        public Itinerary()
        {

        }

    }
}

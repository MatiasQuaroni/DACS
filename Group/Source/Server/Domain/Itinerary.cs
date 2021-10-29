using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class Itinerary
    {
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public IEnumerable<Shipment> Shipments { get; set; }
        public IEnumerable<Leg> Legs { get; set; }

        public Itinerary()
        {
            this.Shipments = new List<Shipment>();
            this.Legs = new List<Leg>();
        }

    }
}

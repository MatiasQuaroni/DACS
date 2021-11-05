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
        public DateTime EndDate { get; set; }
        public IList<Shipment> Shipments { get; set; }
        public IList<Leg> Legs { get; set; }

        public Itinerary()
        {
            this.Id = new Guid();
            this.Shipments = new List<Shipment>();
            this.Legs = new List<Leg>();
            this.IsComplete = false;
        }

    }
}

using System;
using System.Collections.Generic;

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
            this.Id = Guid.NewGuid();
            this.Shipments = new List<Shipment>();
            this.Legs = new List<Leg>();
            this.IsComplete = false;
            this.StartDate = DateTime.Now;
        }

    }
}

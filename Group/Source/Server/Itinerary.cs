using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class Itinerary
    {
        public int numberId { get; set; }
        public Boolean isComplete { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        private IEnumerable<Shipment> shipments;
        private IEnumerable<Leg> legs;
    }
}

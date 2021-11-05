using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class Leg
    {
        public Guid Id { get; set; }
        public Itinerary Itinerary { get; set; }
        public Guid ItineraryId { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
    }
}

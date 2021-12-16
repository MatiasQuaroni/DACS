using System;

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

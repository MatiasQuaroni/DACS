using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Services.DataTransfer
{
    public class ItineraryData
    {
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<ShipmentData> Shipments { get; set; }
        public IEnumerable<LegData> Legs { get; set; }
    }
}

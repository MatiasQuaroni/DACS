using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Services.DTOs
{
    public class ItineraryDTO
    {
        public Guid Id { get; set; }
        public bool IsComplete { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<ShipmentDTO> Shipments { get; set; }
        public IEnumerable<LegDTO> Legs { get; set; }
    }
}

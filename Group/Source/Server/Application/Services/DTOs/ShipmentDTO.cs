using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Services.DTOs
{
    public class ShipmentDTO
    {
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public string Precautions { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public IEnumerable<ShipmentState> States { get; set; }
        public string CustomerDni { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public int DestinationPostalCode { get; set; }
        public string DestinationAddress { get; set; }
        public string DestinationFloor { get; set; }
        public string DestinationNumber { get; set; }
    }
}

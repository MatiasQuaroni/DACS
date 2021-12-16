using System;

namespace Server.Domain
{
    public class ShipmentState
    {
        public Guid Id { get; set; }
        public ShipmentStateEnum CurrentState { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Shipment Shipment { get; set; }
        public Guid ShipmentId { get; set; }
    }
}
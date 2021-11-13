using System;

namespace Server.Application.Services.DataTransfer
{
    public class ShipmentStateData
    {
        public int CurrentState { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

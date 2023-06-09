﻿using System;

namespace Server.Application.Services.DataTransfer
{
    public class ShipmentData
    {
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public string Precautions { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public int Status { get; set; }
        public CustomerData Customer { get; set; }
        public LocationData DestinationAddress { get; set; }
    }
}


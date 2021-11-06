using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Application.Services.DataTransfer
{
    public class ShipmentUpdateData
    {
        public DateTime ArrivalDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public int Weight { get; set; }
        public string Precautions { get; set; }
        public int Status { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public int TrackingNumber { get; set; }
        public int Weight { get; set; }
        public string Precautions { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public IList<ShipmentState> States { get; set; }
        public Location DestinationAddress { get; set; }
        public CustomerInfo Customer { get; set; }

        public Shipment()
        {
            this.States = new List<ShipmentState>();
        }
        public void addNewState(int newStateEnum) 
        { ShipmentState newState = new ShipmentState { CurrentState = (ShipmentStateEnum)newStateEnum,
                                                        FromDate = DateTime.Now};
            this.States.Add(newState);
        }
    }
}

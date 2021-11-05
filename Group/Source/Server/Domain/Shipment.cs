using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public Guid TrackingNumber { get; set; }
        public int Weight { get; set; }
        public string Precautions { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
        public ICollection<ShipmentState> States { get; set; }
        public Guid DestinationAddressId { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Location DestinationAddress { get; set; }
        public virtual CustomerInfo Customer { get; set; }

        public Shipment()
        {
            this.Id = Guid.NewGuid();
            this.TrackingNumber = Guid.NewGuid();
            this.Customer = new CustomerInfo();
            this.DestinationAddress = new Location();
            this.States = new List<ShipmentState>();
            this.addNewState(0);
        }
        public void addNewState(int newStateEnum) 
        { ShipmentState newState = new ShipmentState { CurrentState = (ShipmentStateEnum)newStateEnum,
                                                        FromDate = DateTime.Now,
                                                        ShipmentId=this.Id};
            this.States.Add(newState);
        }
    }
}

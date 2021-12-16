using System;
using System.Collections.Generic;

namespace Server.Domain
{
    public class Shipment
    {
        public Shipment(Guid Id, CustomerInfo pCustomer, Location pLocation)
        {
            this.Id = Id;
            this.TrackingNumber = Guid.NewGuid();
            this.Customer = pCustomer;
            this.DestinationAddress = pLocation;
            this.States = new List<ShipmentState>();
            this.addNewState(0);
        }

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
                
        }

        public void addNewState(int newStateEnum) 
        { ShipmentState newState = new ShipmentState { CurrentState = (ShipmentStateEnum)newStateEnum,
                                                        FromDate = DateTime.Now,
                                                        ShipmentId=this.Id};
            this.States.Add(newState);
        }
    }
}

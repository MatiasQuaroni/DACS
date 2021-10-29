using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Domain;
using Server.Domain.Repositories;

namespace Server.Persistence.Repositories
{
    public class ShipmentRepository : Repository<Shipment, RoadsDbContext> , IShipmentRepository 
    {
        public ShipmentRepository(RoadsDbContext pDbContext) : base(pDbContext)
        {

        }

        public IEnumerable<Shipment> GetByArrivalDate(DateTime arrivalDate)
        {
            var shipments = new List<Shipment>();
            foreach(var item in this.iDbContext.Set<Shipment>())
            {
                if (item.ArrivalDate == arrivalDate)
                {
                    shipments.Add(item);
                }
            }
            return shipments;
        }

        public IEnumerable<Shipment> GetByStatus(int status)
        {
            var shipments = new List<Shipment>();
            foreach (var item in this.iDbContext.Set<Shipment>())
            {
                if (item.States.Last().CurrentState == (ShipmentStateEnum)status)
                {
                    shipments.Add(item);
                }
            }
            return shipments;
        }

        public IEnumerable<Shipment> GetByPostalCode(int postalCode)
        {
            var shipments = new List<Shipment>();
            foreach (var item in this.iDbContext.Set<Shipment>())
            {
                if (item.DestinationAddress.PostalCode == postalCode)
                {
                    shipments.Add(item);
                }
            }
            return shipments;
        }
        public Shipment GetByTrackingNumber(Guid trackingNumber)
        {
            return this.iDbContext.Set<Shipment>().Single(s => s.TrackingNumber == trackingNumber);
        }
    }
}

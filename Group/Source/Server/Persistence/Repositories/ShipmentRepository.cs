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
        public IEnumerable<Shipment> GetAllShipments()
        { List<Shipment> shipments;
            shipments = this.iDbContext.Set<Shipment>().Include(s => s.Customer).Include(s=>s.DestinationAddress).ToList(); 
            return shipments;
        }
        public override Shipment Get(Guid pId) 
        {
            var shipment = iDbContext.Set<Shipment>().Where
                (s => s.Id == pId).Include(s => s.Customer).Include(s=> s.DestinationAddress).FirstOrDefault();
            return (Shipment) shipment;
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

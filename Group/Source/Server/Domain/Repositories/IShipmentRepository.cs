using System;
using System.Collections.Generic;

namespace Server.Domain.Repositories
{
   public interface IShipmentRepository : IRepository<Shipment>
    {
        Shipment GetByTrackingNumber(Guid trackingNumber);
        IEnumerable<Shipment> GetByArrivalDate(DateTime arrivalDate);
        IEnumerable<Shipment> GetByStatus(int status);
        IEnumerable<Shipment> GetByPostalCode(int postalCode);

    }
}

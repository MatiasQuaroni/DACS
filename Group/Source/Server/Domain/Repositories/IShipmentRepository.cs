using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Domain.Repositories
{
   public interface IShipmentRepository : IRepository<Shipment>
    {
        IQueryable<Shipment> GetAllShipments();
        IEnumerable<Shipment> GetByFilter();
    }
}

using System;
using System.Collections.Generic;

namespace Server.Domain.Repositories
{
   public interface IShipmentRepository : IRepository<Shipment>
    {
        IEnumerable<Shipment> GetByFilter();
    }
}

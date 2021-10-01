using System;
using System.Collections.Generic;
using Server.Domain;

namespace Server.Persistence
{
   public interface IShipmentRepository : IRepository<Shipment>
    {
        IEnumerable<Shipment> GetByFilter();
    }
}

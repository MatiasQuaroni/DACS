using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL
{
    interface IShipmentRepository : IRepository<Shipment>
    {
        IEnumerable<Shipment> GetByFilter();
    }
}

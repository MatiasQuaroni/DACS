using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.DAL.EF
{
    public class ShipmentRepository : Repository<Shipment, RoadsDbContext> , IShipmentRepository 
    {
        public ShipmentRepository(RoadsDbContext pDbContext) : base(pDbContext)
        {

        }

        public IEnumerable<Shipment> GetByFilter()
        {
            throw new NotImplementedException();
        }
    }
}

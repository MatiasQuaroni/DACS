using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Domain;

namespace Server.Persistence.Repositories
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

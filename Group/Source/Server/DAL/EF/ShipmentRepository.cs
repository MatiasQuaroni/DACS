using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.DAL.EF
{
    public class ShipmentRepository : Repository<Shipment, ProgramDbContext> , IShipmentRepository 
    {
        public ShipmentRepository(ProgramDbContext pDbContext) : base(pDbContext)
        {

        }

        public IEnumerable<Shipment> GetByFilter(string pArrivalDate, string pPostalCode, int pStatus)
        {
            throw new NotImplementedException();
        }
    }
}

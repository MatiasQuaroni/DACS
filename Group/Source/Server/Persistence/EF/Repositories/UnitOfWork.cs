using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Persistence
{
    public class UnitOfWork: IUnitOfWork 
    {
            private RoadsDbContext iDbContext { get; }
            public IShipmentRepository ShipmentRepository { get; }
            public IUserRepository UserRepository { get; }

        public UnitOfWork(RoadsDbContext pContext)
            {
                this.iDbContext = pContext;
                this.ShipmentRepository = new ShipmentRepository(iDbContext);
                this.UserRepository = new UserRepository(iDbContext);
            }

            public void Complete()
            {
                iDbContext.SaveChanges();
            }
            public void Dispose()
            {
                iDbContext.Dispose();
            }
        }
    }
}

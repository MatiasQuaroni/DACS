using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domain;
using Server.Persistence;

namespace Server.Persistence.EF.Repositories
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

        IShipmentRepository IUnitOfWork.ShipmentRepository => throw new NotImplementedException();

        IUserRepository IUnitOfWork.UserRepository => throw new NotImplementedException();
        }
    }


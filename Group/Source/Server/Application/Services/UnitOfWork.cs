using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domain;
using Server.Persistence;
using Server.Persistence.Repositories;

namespace Server.Services
{
    public class UnitOfWork: IUnitOfWork 
    {
        public RoadsDbContext Context { get; private set; }
        public IShipmentRepository ShipmentRepository { get; }
            public IUserRepository UserRepository { get; }

        public UnitOfWork(RoadsDbContext context)
        {
            this.Context = context;
            this.ShipmentRepository = new ShipmentRepository(Context);
            this.UserRepository = new UserRepository(Context);
        }

        public void Complete()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        IShipmentRepository IUnitOfWork.ShipmentRepository => throw new NotImplementedException();

        IUserRepository IUnitOfWork.UserRepository => throw new NotImplementedException();
        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domain.Repositories;

namespace Server.Persistence.UnitOfWork
{
    interface IUnitOfWork : IDisposable
    {
        public void Complete();
        public IShipmentRepository ShipmentRepository { get; }
        public IUserRepository UserRepository { get; } 
    }
}

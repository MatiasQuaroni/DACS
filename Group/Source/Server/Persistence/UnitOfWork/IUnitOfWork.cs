using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Domain.Repositories;
using Server.Domain;
namespace Server.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public RoadsDbContext Context { get; set; }
        public void Complete();
        public IShipmentRepository ShipmentRepository { get; }
        public IUserRepository UserRepository { get; } 
        public IRepository<Location> LocationRepository { get; }
        public IRepository<CustomerInfo> CustomerInfoRepository { get; }
    }
}

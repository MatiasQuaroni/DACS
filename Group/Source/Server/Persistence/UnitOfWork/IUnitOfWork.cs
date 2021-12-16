using System;
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
        public IRepository<Itinerary> ItineraryRepository { get; }
    }
}

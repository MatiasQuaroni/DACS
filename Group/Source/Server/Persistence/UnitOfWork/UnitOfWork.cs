using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Persistence.Repositories;
using Server.Domain.Repositories;
using Server.Domain;

namespace Server.Persistence.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork 
    {
        public RoadsDbContext Context { get; set; }
        public IShipmentRepository ShipmentRepository { get; }
        public IUserRepository UserRepository { get; }
        public IRepository<Location> LocationRepository { get; }
        public IRepository<CustomerInfo> CustomerInfoRepository { get; }
        public IRepository<Itinerary> ItineraryRepository { get; }

        public UnitOfWork(RoadsDbContext context)
        {
            this.Context = context;
            this.ShipmentRepository = new ShipmentRepository(Context);
            this.UserRepository = new UserRepository(Context);
            this.LocationRepository = new LocationRepository(Context);
            this.CustomerInfoRepository = new CustomerInfoRepository(Context);
            this.ItineraryRepository = new ItineraryRepository(Context);
        }

        public void Complete()
        {
            Context.SaveChanges();
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        }
    }


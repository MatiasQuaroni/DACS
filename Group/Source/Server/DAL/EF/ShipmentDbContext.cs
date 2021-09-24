using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.DAL.EF
{
    public class ShipmentDbContext : DbContext
    {
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<Leg> Legs { get; set; }
        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder pModelBuilder)
        {
            pModelBuilder.ApplyConfiguration(new ShipmentEntityConfiguration());
            pModelBuilder.ApplyConfiguration(new ItineraryEntityConfiguration());

        }
    }
}

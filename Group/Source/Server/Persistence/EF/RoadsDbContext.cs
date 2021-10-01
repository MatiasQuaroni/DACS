﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Persistence.EF.ClassMappings;
using Microsoft.EntityFrameworkCore.InMemory;

namespace Server.Persistence.EF
{
    public class RoadsDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=RoadsDB; User Id=sa; Password=dacs2021!");
            optionsBuilder.UseInMemoryDatabase("Roads");
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShipmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItineraryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LegEntityConfiguration());
            modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerInfoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileInfoEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentStateEntityConfiguration());
        }
        public DbSet<Shipment> Shipment { get; set; }

    }
}

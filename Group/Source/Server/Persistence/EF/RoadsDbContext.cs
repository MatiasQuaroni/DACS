using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Persistence.EF.ClassMappings;

namespace Server.Persistence.EF
{
    public class RoadsDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
 
        protected override void OnModelCreating(ModelBuilder pModelBuilder)
        {
            pModelBuilder.ApplyConfiguration(new ShipmentEntityConfiguration());
            pModelBuilder.ApplyConfiguration(new ItineraryEntityConfiguration());
            pModelBuilder.ApplyConfiguration(new LegEntityConfiguration());
            pModelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
            pModelBuilder.ApplyConfiguration(new CustomerInfoEntityConfiguration());
            pModelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            pModelBuilder.ApplyConfiguration(new ProfileInfoEntityConfiguration());

        }
    }
}

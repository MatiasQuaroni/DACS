using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.DAL.EF
{
    public class ProgramDbContext : DbContext
    {
        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(ModelBuilder pModelBuilder)
        {
            pModelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(pModelBuilder);
        }
    }
}

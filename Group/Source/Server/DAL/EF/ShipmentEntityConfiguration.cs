using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.ModelConfiguration;

namespace Server.DAL.EF
{
    public class ShipmentEntityConfiguration : EntityTypeConfiguration<Shipment>
    {
        public ShipmentEntityConfiguration()
        {
            this.ToTable("ShipmentInfo");
            this.HasKey<Guid>(s => s.Id);
        }
    }
}

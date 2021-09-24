using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Persistence.EF.ClassMappings
{
    public class ShipmentEntityConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("ShipmentInfo");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.TrackingNumber);
            builder.Property(s => s.Weight);
            builder.Property(s => s.Precautions);
            builder.Property(s => s.EstimatedArrivalDate);
            builder.Property(s => s.ArrivalDate);
            builder.HasMany<ShipmentState>(s => (ICollection<ShipmentState>)s.States);
        }
    }
}

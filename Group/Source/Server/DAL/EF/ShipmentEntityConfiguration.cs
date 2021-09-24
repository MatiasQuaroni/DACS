using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DAL.EF
{
    public class ShipmentEntityConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.ToTable("ShipmentInfo");
            builder.HasKey(s => s.Id);

            builder.Property(s => s.TrackingNumber).HasColumnName("TrackingNumber");
            builder.Property(s => s.Weight).HasColumnName("TrackingNumber");
            builder.Property(s => s.Precautions).HasColumnName("Precautions");
            builder.Property(s => s.EstimatedArrivalDate).HasColumnName("EstimatedArrivalDate");
            builder.Property(s => s.ArrivalDate).HasColumnName("ArrivalDate");
            builder.HasMany<ShipmentState>(s => (ICollection<ShipmentState>)s.States);
        }
    }
}

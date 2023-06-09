﻿using Server.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Persistence.ClassMappings
{
    public class ShipmentEntityConfiguration : IEntityTypeConfiguration<Shipment>
    {
        public void Configure(EntityTypeBuilder<Shipment> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.TrackingNumber);
            builder.Property(s => s.Weight);
            builder.Property(s => s.Precautions);
            builder.Property(s => s.EstimatedArrivalDate);
            builder.Property(s => s.ArrivalDate);
            builder.HasMany(s => s.States).WithOne(ss => ss.Shipment).HasForeignKey(ss => ss.ShipmentId);
        }
    }
}

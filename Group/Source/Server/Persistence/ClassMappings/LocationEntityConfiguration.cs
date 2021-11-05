using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Domain;
using System;
using System.Linq;

namespace Server.Persistence.ClassMappings
{
    internal class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            var converter = new ValueConverter<double[], string>(
                v => string.Join("/", v),
                v => v.Split("/", StringSplitOptions.RemoveEmptyEntries).Select(val => double.Parse(val)).ToArray());

            builder.HasKey(l => l.Id);
            builder.Property(l => l.Address);
            builder.Property(l => l.Floor);
            builder.Property(l => l.Number);
            builder.Property(l => l.PostalCode);
            builder.Property(l => l.Coordinates).HasConversion(converter); ;
            builder.Property(l => l.Type);
            builder.HasOne<Shipment>(l => l.Shipment).WithOne(s => s.DestinationAddress).HasForeignKey<Shipment>(da => da.DestinationAddressId);
        }
    }
}
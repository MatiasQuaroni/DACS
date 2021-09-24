using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Persistence.EF.ClassMappings
{
    internal class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Address);
            builder.Property(l => l.Floor);
            builder.Property(l => l.Number);
            builder.Property(l => l.PostalCode);
            builder.Property(l => l.Coordinates);
            builder.Property(l => l.Type);
        }
    }
}
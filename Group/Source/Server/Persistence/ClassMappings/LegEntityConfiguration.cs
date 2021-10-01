using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Persistence.ClassMappings
{
    internal class LegEntityConfiguration : IEntityTypeConfiguration<Leg>
    {
        public void Configure(EntityTypeBuilder<Leg> builder)
        {
            builder.Ignore(l => l.StartLocation);
            builder.Ignore(l => l.EndLocation);
            builder.HasKey(l => l.Id);
            //builder.Property(l => l.StartLocation);
            //builder.Property(l => l.EndLocation);
        }
    }
}
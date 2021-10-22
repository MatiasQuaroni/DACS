using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Server.Domain;

namespace Server.Persistence.ClassMappings
{
    internal class ShipmentStateEntityConfiguration : IEntityTypeConfiguration<ShipmentState>
    {
        public void Configure(EntityTypeBuilder<ShipmentState> builder)
        {
            builder.Property(ss => ss.CurrentState);
            builder.Property(ss => ss.FromDate);
            builder.Property(ss => ss.ToDate);
            builder.HasNoKey();
        }
    }
}

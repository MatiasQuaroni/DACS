using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DAL.EF
{
    internal class LegEntityConfiguration : IEntityTypeConfiguration<Leg>
    {
        public void Configure(EntityTypeBuilder<Leg> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.StartLocation).HasColumnName("StartLocation");
            builder.Property(l => l.EndLocation).HasColumnName("EndLocation");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DAL.EF
{
    internal class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Address).HasColumnName("Address");
            builder.Property(l => l.Floor).HasColumnName("Floor");
            builder.Property(l => l.Number).HasColumnName("Number");
            builder.Property(l => l.PostalCode).HasColumnName("PostalCode");
            builder.Property(l => l.Coordinates).HasColumnName("Coordinates");
            builder.Property(l => l.Type).HasColumnName("Type");
        }
    }
}
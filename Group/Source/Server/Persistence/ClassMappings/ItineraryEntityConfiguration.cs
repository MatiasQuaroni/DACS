using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Persistence.ClassMappings
{
    public class ItineraryEntityConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.IsComplete);
            builder.Property(i => i.StartDate);
            builder.Property(i => i.EndDate);
            builder.HasMany(i => i.Legs).WithOne(l => l.Itinerary).HasForeignKey(l => l.ItineraryId);
        }
    }
}

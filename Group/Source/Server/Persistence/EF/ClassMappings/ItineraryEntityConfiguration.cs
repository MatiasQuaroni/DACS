using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL.EF
{
    public class ItineraryEntityConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.ToTable("ItineraryInfo");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.IsComplete);
            builder.Property(i => i.StartDate);
            builder.Property(i => i.EndDate);
        }
    }
}

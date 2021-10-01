using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Persistence.ClassMappings
{
    internal class CustomerInfoEntityConfiguration : IEntityTypeConfiguration<CustomerInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerInfo> builder)
        {
            builder.ToTable("CustomerInfo");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci=> ci.Name);
            builder.Property(ci => ci.Dni);
            builder.Property(ci => ci.Email);
            builder.Property(ci => ci.PhoneNumber);
        }
    }
}
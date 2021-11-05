using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Persistence.ClassMappings
{
    internal class CustomerInfoEntityConfiguration : IEntityTypeConfiguration<CustomerInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerInfo> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.Property(ci=> ci.Name);
            builder.Property(ci => ci.Dni);
            builder.Property(ci => ci.Email);
            builder.Property(ci => ci.PhoneNumber);
            builder.HasOne<Shipment>(ci =>ci.Shipment ).WithOne(s => s.Customer).HasForeignKey<Shipment>(s => s.CustomerId);
        }
    }
}
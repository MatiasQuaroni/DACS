using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.DAL.EF
{
    internal class CustomerInfoEntityConfiguration : IEntityTypeConfiguration<CustomerInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerInfo> builder)
        {
            builder.ToTable("CustomerInfor");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci=> ci.Name).HasColumnName("Name");
            builder.Property(ci => ci.Dni).HasColumnName("DNI");
            builder.Property(ci => ci.Email).HasColumnName("Email");
            builder.Property(ci => ci.PhoneNumber).HasColumnName("PhoneNumber");
        }
    }
}
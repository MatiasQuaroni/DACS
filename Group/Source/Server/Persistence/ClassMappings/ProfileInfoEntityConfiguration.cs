using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Server.Domain;

namespace Server.Persistence.ClassMappings
{
    public class ProfileInfoEntityConfiguration : IEntityTypeConfiguration<ProfileInfo>
    {
        public void Configure(EntityTypeBuilder<ProfileInfo> builder)
        {
            builder.HasNoKey();
            builder.Property(p => p.DisplayName);
            builder.Property(p => p.EmailAddress);
            builder.Property(p => p.PhoneNumber);

        }
    }
}
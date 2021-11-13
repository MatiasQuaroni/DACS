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
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DisplayName);
            builder.Property(p => p.EmailAddress);
            builder.Property(p => p.PhoneNumber);
            builder.HasOne<User>(p => p.User).WithOne(u => u.ProfileInfo).HasForeignKey<User>(u => u.ProfileInfoId);

        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL.EF
{
    public class ProfileInfoEntityConfiguration : IEntityTypeConfiguration<ProfileInfo>
    {
        public void Configure(EntityTypeBuilder<ProfileInfo> builder)
        {
            builder.Property(p => p.DisplayName).HasColumnName("Displayname");
            builder.Property(p => p.EmailAddress).HasColumnName("Email");
            builder.Property(p => p.PhoneNumber).HasColumnName("Phone number");

        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Persistence.EF.ClassMappings
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            
            builder.ToTable("UserInfo");                                     
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName);
            builder.Property(p => p.Password);
            builder.Ignore(p => p.UserState);
            builder.Ignore(p => p.ProfileInfo);
        }
    }
    }

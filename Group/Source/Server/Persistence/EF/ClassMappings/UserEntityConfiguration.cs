using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DAL.EF
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("UserInfo");                                     
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName);
            builder.Property(p => p.Password);
            builder.HasMany<UserState>(u => (ICollection<UserState>)u.UserState);
        }
    }
}

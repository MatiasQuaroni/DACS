using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;

namespace Server.Persistence.ClassMappings
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName);
            builder.Property(p => p.Password);
            builder.HasMany(s => s.UserStates).WithOne(us => us.User).HasForeignKey(us => us.UserId);
        }
    }
}

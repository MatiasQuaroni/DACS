using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domain;


namespace Server.Persistence.ClassMappings
{
    public class UserStateEntityConfiguration: IEntityTypeConfiguration<UserState>
    {
        public void Configure(EntityTypeBuilder<UserState> builder)
        {
            builder.HasKey(us => us.Id);
            builder.Property(us => us.Date);
            builder.Property(us => us.Status);
        }
    }
}

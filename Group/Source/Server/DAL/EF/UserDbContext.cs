using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.DAL.EF
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProfileInfo> Profiles { get; set; }

    protected override void OnModelCreating(ModelBuilder pModelBuilder)
        {
            pModelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            pModelBuilder.ApplyConfiguration(new ProfileInfoEntityConfiguration());

        }

    }
    }
}

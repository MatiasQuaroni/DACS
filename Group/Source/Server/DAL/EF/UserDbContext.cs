using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.DAL
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ProfileInfo> Profiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("UserInfo")
                                       .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(p => p.UserName)
                .HasColumnName("Username")
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .HasMaxLength(50)
                .HasColumnName("Password");

            modelBuilder.Entity<UserState>()
                .Property(p => p.Status)
                .HasColumnName("Status");

            modelBuilder.Entity<ProfileInfo>()
                .Property(p => p.DisplayName)
                .HasColumnName("Displayname");

            modelBuilder.Entity<ProfileInfo>()
                .Property(p => p.EmailAddress)
                .HasColumnName("Email");

            modelBuilder.Entity<ProfileInfo>()
                .Property(p => p.PhoneNumber)
                .HasColumnName("Phone number");

        }
    }
}

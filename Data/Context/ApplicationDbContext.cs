using EventManageApp.Core.Enums;
using EventManageApp.Core.Services;
using EventManageApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManageApp.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<EventBookings> EventBookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(u => u.UserType).HasConversion<string>();
                entity.Property(u => u.Status).HasConversion<string>();
                entity.HasQueryFilter(u => u.DeletedAt == null);
                entity.HasData(new Users
                {
                    Id = 1,
                    UserType = UserType.Admin,
                    Name = "Admin",
                    Contact = "1234567890",
                    Email = "admin@exmaple.com",
                    Status = UserStatus.Active,
                    Password = AuthService.HashPassword("admin@1234")
                });
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Status).HasConversion<string>();
                entity.HasQueryFilter(e => e.DeletedAt == null);
            });

            modelBuilder.Entity<EventBookings>(entity =>
            {
                entity.Property(e => e.Status).HasConversion<string>();
                entity.HasQueryFilter(eb => eb.Event.DeletedAt == null);

                entity.HasOne(eb => eb.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(eb => eb.EventId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(eb => eb.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(eb => eb.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            });
        }



    }
}
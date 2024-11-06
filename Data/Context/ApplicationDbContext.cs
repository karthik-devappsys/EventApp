

using BCrypt.Net;
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
                    // Password =  AuthService.HashPassword("admin@1234")
                });

                modelBuilder.Entity<Events>(entity =>
                {
                    entity.Property(e => e.Status).HasConversion<string>();
                });
            });
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {

        //     optionsBuilder.UseSqlServer("Data Source=DESKTOP-NQADDIJ;Initial Catalog=Event_Mangement;Integrated Security=True;Encrypt=True;Trust Server Certificate=True")
        //     .EnableSensitiveDataLogging().LogTo(Console.WriteLine, LogLevel.Information);
        // }

    }
}
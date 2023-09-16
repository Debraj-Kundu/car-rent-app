using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataContext
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<User>().HasData(
                   new User() { Id = 1, Name = "UserOne", Email = "user1@user.com", Password = "User@123", Role = "User", CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow },
                   new User() { Id = 2, Name = "UserTwo", Email = "user2@user.com", Password = "User@123", Role = "User", CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow },
                   new User() { Id = 3, Name = "UserThree", Email = "user3@user.com", Password = "User@123", Role = "User", CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow },
                   new User() { Id = 4, Name = "AdminOne", Email = "admin1@admin.com", Password = "Admin@123", Role = "Admin", CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow },
                   new User() { Id = 5, Name = "AdminTwo", Email = "admin2@admin.com", Password = "Admin@123", Role = "Admin", CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow }
            );
            modelBuilder.Entity<Car>().HasData(
                new Car() { Id = 1, Maker = "Maruti", Model = "Swift Desire", RentalPrice = 58000, AvailabilityStatus = true, CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow },
                new Car() { Id = 2, Maker = "Hyundai", Model = "i20", RentalPrice = 64000, AvailabilityStatus = true, CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow },
                new Car() { Id = 3, Maker = "Maruti", Model = "Alto", RentalPrice = 46000, AvailabilityStatus = true, CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow }
            );
        }
    }
}

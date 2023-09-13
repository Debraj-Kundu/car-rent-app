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
                   new User() { Id = 1, UserId = "1", Name = "UserOne", Email = "user1@user.com", Password = "User@123", Role = "User", CreatedOnDate = DateTimeOffset.UtcNow, ModifiedOnDate = DateTimeOffset.UtcNow }

            );
        }
    }
}

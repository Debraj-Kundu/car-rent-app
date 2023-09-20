using DataLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DataContext
{
    public class CarDomainDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RentedCar> RentedCars { get; set; }
        public CarDomainDbContext(DbContextOptions<CarDomainDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //new DbInitializer(builder).Seed();
        }
    }
}

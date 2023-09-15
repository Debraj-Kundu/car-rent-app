using DataLayer.DataContext;
using DataLayer.Entity;
using DataLayer.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using SharedLayer.Core.ValueObjects;
using SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Implementation
{
    public class RentedCarRepository : Repository<RentedCar>, IRentedCarRepository
    {
        public CarDomainDbContext Context { get; }

        public RentedCarRepository(CarDomainDbContext context) : base(context)
        {
            Context = context;
        }
        public async Task<OperationResult<IEnumerable<RentedCar>>> GetAllAsync()
        {
            IEnumerable<RentedCar> result = await base.All()
                                                .Include(rc => rc.Car)
                                                .Include(rc => rc.User)
                                                .ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<RentedCar>>(result, true, message);
        }

        public async Task<OperationResult<RentedCar>> GetByIdAsync(int id)
        {
            var result = await Context.RentedCars.Include(rc => rc.Car)
                                                .Include(rc => rc.User)
                                                .FirstOrDefaultAsync(rc => rc.Id == id);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<RentedCar>(result, true, message);
        }

        public async Task<OperationResult<RentedCar>> GetByCarIdAsync(int id)
        {
            var result = await Context.RentedCars.Include(rc => rc.Car)
                                                .Include(rc => rc.User)
                                                .FirstOrDefaultAsync(rc => rc.CarId == id);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<RentedCar>(result, true, message);
        }
        public async Task<OperationResult<RentedCar>> GetByUserIdAsync(int id)
        {
            var result = await Context.RentedCars.Include(rc => rc.Car)
                                                .Include(rc => rc.User)
                                                .FirstOrDefaultAsync(rc => rc.UserId == id);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<RentedCar>(result, true, message);
        }

        public new async Task<OperationResult> AddAsync(RentedCar entity)
        {
            await base.AddAsync(entity);
            Message message = new Message(string.Empty, "Created Successfully");
            return new OperationResult(true, message);
        }
    }
}

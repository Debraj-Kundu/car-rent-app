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
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarDomainDbContext Context { get; }

        public CarRepository(CarDomainDbContext context) : base(context)
        {
            Context = context;
        }

        public override async Task UpdateAsync(Car entity)
        {
            await base.UpdateAsync(entity);
        }

        public async Task<OperationResult<IEnumerable<Car>>> GetAllAsync()
        {
            IEnumerable<Car> result = await base.All().ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<Car>>(result, true, message);
        }

        public async Task<OperationResult<Car>> GetByIdAsync(string id)
        {
            var result = await Context.Cars.FindAsync(id);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<Car>(result, true, message);
        }

        public new async Task<OperationResult> AddAsync(Car entity)
        {
            await base.AddAsync(entity);
            Message message = new Message(string.Empty, "Created Successfully");
            return new OperationResult(true, message);
        }
    }
}

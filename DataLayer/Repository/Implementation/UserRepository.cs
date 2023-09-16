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
    public class UserRepository : Repository<User>, IUserRepository
    {
        public CarDomainDbContext Context { get; }

        public UserRepository(CarDomainDbContext context) : base(context)
        {
            Context = context;
        }
        public override async Task UpdateAsync(User entity)
        {
            await base.UpdateAsync(entity);
        }
        

        public async Task<OperationResult<IEnumerable<User>>> GetAllAsync()
        {
            IEnumerable<User> result = await base.All().ToListAsync();
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<IEnumerable<User>>(result, true, message);
        }

        public async Task<OperationResult<User>> GetByIdAsync(int id)
        {
            var result = await Context.Users.FindAsync(id);
            Message message = new Message(string.Empty, "Return Successfully");
            return new OperationResult<User>(result, true, message);
        }
    }
}

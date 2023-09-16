using DataLayer.Entity;
using SharedLayer.Core.ValueObjects;
using SharedLayer.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        Task<OperationResult<IEnumerable<User>>> GetAllAsync();
        Task<OperationResult<User>> GetByIdAsync(int id);
        Task<OperationResult<User>> GetByDetailsAsync(string email, string password);

    }
}

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
    public interface ICarRepository : IRepository<Car>
    {
        Task<OperationResult<IEnumerable<Car>>> GetAllAsync();
        Task<OperationResult<Car>> GetByIdAsync(string id);
    }
}

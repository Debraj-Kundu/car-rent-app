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
    public interface IRentedCarRepository : IRepository<RentedCar>
    {
        Task<OperationResult<IEnumerable<RentedCar>>> GetAllAsync();
        Task<OperationResult<RentedCar>> GetByIdAsync(int id);
        new Task<OperationResult> AddAsync(RentedCar entity);
        Task<OperationResult<RentedCar>> GetByCarIdAsync(int id);
        Task<OperationResult<RentedCar>> GetByUserIdAsync(int id);
    }
}

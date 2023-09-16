using BuisnessLayer.Domain;
using SharedLayer.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.CarAppService.Interface
{
    public interface IRentedCarService
    {
        Task<OperationResult<IEnumerable<RentedCarDomain>>> GetAllRentedCarsAsync();
        Task<OperationResult<RentedCarDomain>> GetRentedCarByIdAsync(int id);
        Task<OperationResult> CreateRentedCarAsync(RentedCarDomain car);
        Task<OperationResult<IEnumerable<RentedCarDomain>>> GetRentedCarByUserIdAsync(int id);
        Task<OperationResult<IEnumerable<RentedCarDomain>>> GetRentedCarByCarIdAsync(int id);
        Task<OperationResult> UpdateRentedCarAsync(RentedCarDomain car);
        Task<OperationResult> RemoveRentedCarAsync(int id);
    }
}

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
        //Task<OperationResult> UpdateCarAsync(CarDomain car);
        //Task<OperationResult> RemoveCarAsync(int id);
    }
}

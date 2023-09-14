using BuisnessLayer.Domain;
using DataLayer.Entity;
using SharedLayer.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.CarAppService.Interface
{
    public interface ICarService
    {
        Task<OperationResult<IEnumerable<CarDomain>>> GetAllCarsAsync();
        Task<OperationResult<CarDomain>> GetCarByIdAsync(string id);
    }
}

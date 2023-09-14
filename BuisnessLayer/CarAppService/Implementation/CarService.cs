using AutoMapper;
using BuisnessLayer.CarAppService.Interface;
using BuisnessLayer.Domain;
using DataLayer.Entity;
using DataLayer.UoW;
using SharedLayer.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.CarAppService.Implementation
{
    public class CarService : ICarService
    {
        public ICarUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public CarService(ICarUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<CarDomain>>> GetAllCarsAsync()
        {
            IEnumerable<CarDomain> result = new List<CarDomain>();
            OperationResult<IEnumerable<Car>> cars = await UnitOfWork.CarRepository.GetAllAsync();

            if (cars.IsSuccess)
            {
                result = Mapper.Map<IEnumerable<CarDomain>>(cars.Data);

            }
            Message message = new Message(string.Empty, cars.MainMessage.Text);
            return new OperationResult<IEnumerable<CarDomain>>(result, true, message);
        }

        public async Task<OperationResult<CarDomain>> GetCarByIdAsync(object id)
        {
            OperationResult<Car> car = await UnitOfWork.CarRepository.GetByIdAsync(id);
            CarDomain result = null;
            if (car != null && car.IsSuccess)
            {
                result = Mapper.Map<CarDomain>(car);
                Message message = new Message(string.Empty, car.MainMessage.Text);
                return new OperationResult<CarDomain>(result, true, message);
            }
            else
            {
                Message message = new Message(string.Empty, "No car found with id: " + id);
                return new OperationResult<CarDomain>(result, false, message);
            }
        }
    }
}

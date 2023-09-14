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

        public async Task<OperationResult<CarDomain>> GetCarByIdAsync(int id)
        {
            OperationResult<Car> car = await UnitOfWork.CarRepository.GetByIdAsync(id);
            CarDomain result = null;
            if (car.Data != null && car.IsSuccess)
            {
                result = Mapper.Map<CarDomain>(car.Data);
                Message message = new Message(string.Empty, car.MainMessage.Text);
                return new OperationResult<CarDomain>(result, true, message);
            }
            else
            {
                Message message = new Message(string.Empty, "No car found with id: " + id);
                return new OperationResult<CarDomain>(result, false, message);
            }
        }

        public async Task<OperationResult> CreateCarAsync(CarDomain car)
        {
            Car carToCreate = Mapper.Map<CarDomain, Car>(car);
            carToCreate.CreatedOnDate = DateTimeOffset.Now;

            await UnitOfWork.CarRepository.AddAsync(carToCreate);
            car.Id = carToCreate.Id;
            OperationResult result = await UnitOfWork.Commit();

            return new OperationResult(result.IsSuccess, result.MainMessage);
        }

        public async Task<OperationResult> UpdateCarAsync(CarDomain car)
        {
            Car carEntity = Mapper.Map<Car>(car);
            await UnitOfWork.CarRepository.UpdateAsync(carEntity);
            
            OperationResult result = await UnitOfWork.Commit();

            return new OperationResult(result.IsSuccess, result.MainMessage);
        }
    }
}

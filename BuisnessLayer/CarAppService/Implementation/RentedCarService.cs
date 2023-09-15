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
    public class RentedCarService : IRentedCarService
    {
        public ICarUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public RentedCarService(ICarUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<OperationResult> CreateRentedCarAsync(RentedCarDomain car)
        {
            RentedCar carToCreate = Mapper.Map<RentedCarDomain, RentedCar>(car);
            carToCreate.CreatedOnDate = DateTimeOffset.Now;

            await UnitOfWork.RentedCarRepository.AddAsync(carToCreate);
            car.Id = carToCreate.Id;
            OperationResult result = await UnitOfWork.Commit();
            return new OperationResult(result.IsSuccess, result.MainMessage);
        }

        public async Task<OperationResult<IEnumerable<RentedCarDomain>>> GetAllRentedCarsAsync()
        {
            IEnumerable<RentedCarDomain> result = new List<RentedCarDomain>();
            OperationResult<IEnumerable<RentedCar>> cars = await UnitOfWork.RentedCarRepository.GetAllAsync();

            if (cars.IsSuccess)
            {
                result = Mapper.Map<IEnumerable<RentedCarDomain>>(cars.Data);

            }
            Message message = new Message(string.Empty, cars.MainMessage.Text);
            return new OperationResult<IEnumerable<RentedCarDomain>>(result, true, message);
        }

        public async Task<OperationResult<RentedCarDomain>> GetRentedCarByIdAsync(int id)
        {
            OperationResult<RentedCar> car = await UnitOfWork.RentedCarRepository.GetByIdAsync(id);
            RentedCarDomain result = null;
            if (car.Data != null && car.IsSuccess)
            {
                result = Mapper.Map<RentedCarDomain>(car.Data);
                Message message = new Message(string.Empty, car.MainMessage.Text);
                return new OperationResult<RentedCarDomain>(result, true, message);
            }
            else
            {
                Message message = new Message(string.Empty, "No car found with id: " + id);
                return new OperationResult<RentedCarDomain>(result, false, message);
            }
        }
    }
}

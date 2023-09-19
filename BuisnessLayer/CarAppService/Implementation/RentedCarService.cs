using AutoMapper;
using BuisnessLayer.CarAppService.Interface;
using BuisnessLayer.Domain;
using DataLayer.Entity;
using DataLayer.UoW;
using SharedLayer.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        private async Task<bool> Available(int carId, RentedCar carToCreate)
        {
            var result = await GetRentedCarByCarIdAsync(carId);
            
            var rents = result.Data.OrderBy(rc => rc.DateRented).ToList();
            if(!rents.Any())
            {
                return true;
            }
            
            
            if (carToCreate.DateRented == DateTimeOffset.Now && carToCreate.DateReturn < rents[0].DateRented)
            {
                return true;
            }
            if(carToCreate.DateRented > rents[rents.Count - 1].DateReturn)
            {
                return true;
            }
            for (int i = 1; i < rents.Count; i++)
            {
                if (carToCreate.DateRented > rents[i-1].DateReturn && carToCreate.DateReturn < rents[i].DateRented)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<OperationResult> CreateRentedCarAsync(RentedCarDomain car)
        {
            RentedCar carToCreate = Mapper.Map<RentedCarDomain, RentedCar>(car);

            if (Available(car.CarId, carToCreate).Result)
            {
                carToCreate.CreatedOnDate = DateTimeOffset.Now;

                decimal days = (decimal)carToCreate.DateReturn.Subtract(carToCreate.DateRented).TotalDays;

                var price = (await GetCarDetails(car.CarId)).RentalPrice;
                carToCreate.TotalCost = price * days;

                await UnitOfWork.RentedCarRepository.AddAsync(carToCreate);
                car.Id = carToCreate.Id;
            }
            OperationResult result = await UnitOfWork.Commit();
            return new OperationResult(result.IsSuccess, result.MainMessage);
        }

        private async Task<Car> GetCarDetails(int id)
        {
            var car = await UnitOfWork.CarRepository.GetByIdAsync(id);
            return car.Data;
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

        public async Task<OperationResult<IEnumerable<RentedCarDomain>>> GetRentedCarByCarIdAsync(int id)
        {
            OperationResult<IEnumerable<RentedCar>> car = await UnitOfWork.RentedCarRepository.GetByCarIdAsync(id);
            IEnumerable<RentedCarDomain> result = null;
            if (car.Data != null && car.IsSuccess)
            {
                result = Mapper.Map<IEnumerable<RentedCarDomain>>(car.Data);
                Message message = new Message(string.Empty, car.MainMessage.Text);
                return new OperationResult<IEnumerable<RentedCarDomain>>(result, true, message);
            }
            else
            {
                Message message = new Message(string.Empty, "No car found with id: " + id);
                return new OperationResult<IEnumerable<RentedCarDomain>>(result, false, message);
            }
        }

        public async Task<OperationResult<IEnumerable<RentedCarDomain>>> GetRentedCarByUserIdAsync(int id)
        {
            OperationResult<IEnumerable<RentedCar>> car = await UnitOfWork.RentedCarRepository.GetByUserIdAsync(id);
            IEnumerable<RentedCarDomain> result = new List<RentedCarDomain>();
            if (car.Data != null && car.IsSuccess)
            {
                result = Mapper.Map<IEnumerable<RentedCarDomain>>(car.Data);
                Message message = new Message(string.Empty, car.MainMessage.Text);
                return new OperationResult<IEnumerable<RentedCarDomain>>(result, true, message);
            }
            else
            {
                Message message = new Message(string.Empty, "No car found with id: " + id);
                return new OperationResult<IEnumerable<RentedCarDomain>>(result, false, message);
            }
        }

        public async Task<OperationResult> UpdateRentedCarAsync(RentedCarDomain car)
        {
            RentedCar carEntity = Mapper.Map<RentedCar>(car);
            await UnitOfWork.RentedCarRepository.UpdateAsync(carEntity);

            OperationResult result = await UnitOfWork.Commit();

            return new OperationResult(result.IsSuccess, result.MainMessage);
        }

        public async Task<OperationResult> RemoveRentedCarAsync(int id)
        {
            UnitOfWork.RentedCarRepository.Delete(id);
            Message message = new Message(string.Empty, "Deleted Successfully");
            await UnitOfWork.Commit();
            return new OperationResult(true, message);
        }

    }
}

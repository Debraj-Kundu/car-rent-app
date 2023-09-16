using DataLayer.DataContext;
using DataLayer.Repository.Interface;
using SharedLayer.Core.ExceptionManagement;
using SharedLayer.Data.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UoW
{
    public class CarUnitOfWork : UnitOfWork, ICarUnitOfWork
    {
        public CarUnitOfWork(CarDomainDbContext context, ICarRepository carRepository, IRentedCarRepository rentedCarRepository, IUserRepository userRepository, IExceptionManager exceptionManager) : base(context, exceptionManager)
        {
            CarRepository = carRepository;
            RentedCarRepository = rentedCarRepository;
            UserRepository = userRepository;
        }

        public ICarRepository CarRepository { get; }
        public IRentedCarRepository RentedCarRepository { get; }
        public IUserRepository UserRepository { get; }

    }
}

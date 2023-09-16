using DataLayer.Repository.Interface;
using SharedLayer.Data.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.UoW
{
    public interface ICarUnitOfWork : IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IRentedCarRepository RentedCarRepository { get; }
        IUserRepository UserRepository { get; }
    }
}

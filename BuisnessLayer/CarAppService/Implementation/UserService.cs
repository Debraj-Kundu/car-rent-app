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
    public class UserService : IUserService
    {
        public ICarUnitOfWork UnitOfWork { get; }
        public IMapper Mapper { get; }

        public UserService(ICarUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        public async Task<OperationResult<IEnumerable<UserDomain>>> GetAllUsersAsync()
        {
            IEnumerable<UserDomain> result = new List<UserDomain>();
            OperationResult<IEnumerable<User>> users = await UnitOfWork.UserRepository.GetAllAsync();

            if (users.IsSuccess)
            {
                result = Mapper.Map<IEnumerable<UserDomain>>(users.Data);

            }
            Message message = new Message(string.Empty, users.MainMessage.Text);
            return new OperationResult<IEnumerable<UserDomain>>(result, true, message);
        }

        public async Task<OperationResult<UserDomain>> GetUserByIdAsync(int id)
        {
            OperationResult<User> user = await UnitOfWork.UserRepository.GetByIdAsync(id);
            UserDomain result = null;
            if (user.Data != null && user.IsSuccess)
            {
                result = Mapper.Map<UserDomain>(user.Data);
                Message message = new Message(string.Empty, user.MainMessage.Text);
                return new OperationResult<UserDomain>(result, true, message);
            }
            else
            {
                Message message = new Message(string.Empty, "No car found with id: " + id);
                return new OperationResult<UserDomain>(result, false, message);
            }
        }

        public async Task<OperationResult<UserDomain>> GetUserWithDetails(string email, string password)
        {
            OperationResult<User> user = await UnitOfWork.UserRepository.GetByDetailsAsync(email, password);
            UserDomain result = null;
            if (user.Data != null && user.IsSuccess)
            {
                result = Mapper.Map<UserDomain>(user.Data);
                Message message = new Message(string.Empty, user.MainMessage.Text);
                return new OperationResult<UserDomain>(result, true, message);
            }
            else
            {
                Message message = new Message(string.Empty, "Invalid Credentials");
                return new OperationResult<UserDomain>(result, false, message);
            }
        }
    }
}

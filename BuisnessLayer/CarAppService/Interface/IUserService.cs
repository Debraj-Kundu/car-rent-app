using BuisnessLayer.Domain;
using SharedLayer.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.CarAppService.Interface
{
    public interface IUserService
    {
        Task<OperationResult<IEnumerable<UserDomain>>> GetAllUsersAsync();
        Task<OperationResult<UserDomain>> GetUserByIdAsync(int id);
        Task<OperationResult<UserDomain>> GetUserWithDetails(string email, string password);
    }
}

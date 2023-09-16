using AutoMapper;
using BuisnessLayer.CarAppService.Implementation;
using BuisnessLayer.CarAppService.Interface;
using BuisnessLayer.Domain;
using Car_Rental_Application.DTO;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.Core.ValueObjects;

namespace Car_Rental_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; }

        public IMapper Mapper { get; }
        public SharedLayer.Core.Logging.ILogger Logger { get; }

        public UserController(IUserService userService, IMapper mapper, SharedLayer.Core.Logging.ILogger logger)
        {
            UserService = userService;
            Mapper = mapper;
            Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            OperationResult<IEnumerable<UserDomain>> result = await UserService.GetAllUsersAsync();
            IEnumerable<UserDto> cars = Mapper.Map<IEnumerable<UserDto>>(result.Data);
            return Ok(cars);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> Get([FromRoute] int id)
        {
            OperationResult<UserDomain> result = await UserService.GetUserByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                UserDto car = Mapper.Map<UserDto>(result.Data);
                return Ok(car);
            }
            return NotFound();
        }
    }
}

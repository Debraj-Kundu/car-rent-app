using AutoMapper;
using BuisnessLayer.CarAppService.Implementation;
using BuisnessLayer.CarAppService.Interface;
using BuisnessLayer.Domain;
using Car_Rental_Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLayer.Core.ValueObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.DTO;

namespace Car_Rental_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; }
        public IMapper Mapper { get; }
        public JWTSetting JwtSetting { get; }
        public SharedLayer.Core.Logging.ILogger Logger { get; }

        public UserController(IUserService userService, IMapper mapper, IOptions<JWTSetting> options, SharedLayer.Core.Logging.ILogger logger)
        {
            UserService = userService;
            Mapper = mapper;
            JwtSetting = options.Value;
            Logger = logger;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDto>>> Get()
        {
            OperationResult<IEnumerable<UserDomain>> result = await UserService.GetAllUsersAsync();
            IEnumerable<UserDto> cars = Mapper.Map<IEnumerable<UserDto>>(result.Data);
            return Ok(cars);
        }

        [HttpGet("{id:int}")]
        [Authorize]
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

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate(UserDto user)
        {
            var result = await UserService.GetUserWithDetails(user.Email, user.Password);
            if (result.Data == null)
                return Unauthorized();

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(JwtSetting.securitykey);
            var userClaims = new Claim[]{
                                new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()),
                                new Claim(ClaimTypes.Name, result.Data.Name),
                                new Claim(ClaimTypes.Email, result.Data.Email),
                                new Claim(ClaimTypes.Role, result.Data.Role)
                            };
            var userIdentity = new ClaimsIdentity(userClaims);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = userIdentity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);

            return Ok(new { token = finaltoken });
        }
    }
}

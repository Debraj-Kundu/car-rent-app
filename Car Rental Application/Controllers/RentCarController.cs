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
    public class RentCarController : ControllerBase
    {
        public IRentedCarService RentedCarService { get; }

        public IMapper Mapper { get; }
        public SharedLayer.Core.Logging.ILogger Logger { get; }

        public RentCarController(IRentedCarService rentedCarService, IMapper mapper, SharedLayer.Core.Logging.ILogger logger)
        {
            RentedCarService = rentedCarService;
            Mapper = mapper;
            Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentedCarDto>>> Get()
        {
            OperationResult<IEnumerable<RentedCarDomain>> result = await RentedCarService.GetAllRentedCarsAsync();
            IEnumerable<RentedCarDto> cars = Mapper.Map<IEnumerable<RentedCarDto>>(result.Data);
            return Ok(cars);
        }

        [HttpPost]
        public async Task<ActionResult> Post(RentedCarDto car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            RentedCarDomain carToCreate = Mapper.Map<RentedCarDomain>(car);
            var result = await RentedCarService.CreateRentedCarAsync(carToCreate);
            if (result.IsSuccess)
            {
                return Created(nameof(Post), car);
            }
            return BadRequest(result.MainMessage.Text);
        }
    }
}

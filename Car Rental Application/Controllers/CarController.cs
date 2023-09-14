using AutoMapper;
using BuisnessLayer.CarAppService.Interface;
using BuisnessLayer.Domain;
using Car_Rental_Application.DTO;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.Core.ValueObjects;

namespace Car_Rental_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ICarService CarService { get; }

        public IMapper Mapper { get; }
        public SharedLayer.Core.Logging.ILogger Logger { get; }

        public CarController(ICarService carService, IMapper mapper, SharedLayer.Core.Logging.ILogger logger)
        {
            CarService = carService;
            Mapper = mapper;
            Logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDto>>> Get()
        {
            OperationResult<IEnumerable<CarDomain>> result = await CarService.GetAllCarsAsync();
            IEnumerable<CarDto> cars = Mapper.Map<IEnumerable<CarDto>>(result.Data);
            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarDto>> Get([FromRoute] string id)
        {
            OperationResult<CarDomain> result = await CarService.GetCarByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                CarDto car = Mapper.Map<CarDto>(result.Data);
                return Ok(car);
            }
            return NotFound();
        }
    }
}

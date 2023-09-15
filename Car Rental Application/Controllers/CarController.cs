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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CarDto>> Get([FromRoute] int id)
        {
            OperationResult<CarDomain> result = await CarService.GetCarByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                CarDto car = Mapper.Map<CarDto>(result.Data);
                return Ok(car);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(CarDto car)
        {
            if (car == null)
            {
                return BadRequest();
            }
            CarDomain carToCreate = Mapper.Map<CarDomain>(car);
            var result = await CarService.CreateCarAsync(carToCreate);
            if(result.IsSuccess)
            {
                return Created(nameof(Post), car);
            }
            return BadRequest(result.MainMessage.Text);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, CarDto car)
        {
            car.Id = id;
            var carDomain = Mapper.Map<CarDomain>(car);
            var result = await CarService.UpdateCarAsync(carDomain);
            if(result.IsSuccess)
                return Created(nameof(Put), car);
            return BadRequest(result.MainMessage.Text);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await CarService.RemoveCarAsync(id);
            if (result.IsSuccess)
                return Ok();
            return BadRequest(result.MainMessage.Text);
        }
    }
}

using AutoMapper;
using BuisnessLayer.CarAppService.Implementation;
using BuisnessLayer.CarAppService.Interface;
using BuisnessLayer.Domain;
using Car_Rental_Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.Core.ValueObjects;
using WebAPI.Service;

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
        [Authorize]
        public async Task<ActionResult<IEnumerable<RentedCarDto>>> Get()
        {
            OperationResult<IEnumerable<RentedCarDomain>> result = await RentedCarService.GetAllRentedCarsAsync();
            IEnumerable<RentedCarDto> cars = Mapper.Map<IEnumerable<RentedCarDto>>(result.Data);
            return Ok(cars);
        }

        [HttpPost]
        [Authorize]
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

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<ActionResult<RentedCarDto>> Get([FromRoute] int id)
        {
            OperationResult<RentedCarDomain> result = await RentedCarService.GetRentedCarByIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                RentedCarDto car = Mapper.Map<RentedCarDto>(result.Data);
                return Ok(car);
            }
            return NotFound();
        }
        [HttpGet("/api/[controller]/[action]/{id:int}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RentedCarDto>>> GetByCarId([FromRoute] int id)
        {
            OperationResult<IEnumerable<RentedCarDomain>> result = await RentedCarService.GetRentedCarByCarIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                IEnumerable<RentedCarDto> car = Mapper.Map<IEnumerable<RentedCarDto>>(result.Data);
                return Ok(car);
            }
            return NotFound();
        }

        [HttpGet("/api/[controller]/[action]/{id:int}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<RentedCarDto>>> GetByUserId([FromRoute] int id)
        {
            OperationResult<IEnumerable<RentedCarDomain>> result = await RentedCarService.GetRentedCarByUserIdAsync(id);
            if (result.IsSuccess && result.Data != null)
            {
                IEnumerable<RentedCarDto> car = Mapper.Map<IEnumerable<RentedCarDto>>(result.Data);
                return Ok(car);
            }
            return NotFound();
        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Put(int id, RentedCarDto car)
        {
            car.Id = id;
            var carDomain = Mapper.Map<RentedCarDomain>(car);
            var result = await RentedCarService.UpdateRentedCarAsync(carDomain);
            if (result.IsSuccess)
                return Created(nameof(Put), car);
            return BadRequest(result.MainMessage.Text);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await RentedCarService.RemoveRentedCarAsync(id);
            if (result.IsSuccess)
                return Ok();
            return BadRequest(result.MainMessage.Text);
        }
    }
}

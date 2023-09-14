using AutoMapper;
using BuisnessLayer.CarAppService.Interface;
using Car_Rental_Application.DTO;
using Microsoft.AspNetCore.Mvc;

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
            var result = await CarService.GetAllCarsAsync();
            var cars = Mapper.Map<IEnumerable<CarDto>>(result.Data);
            return Ok(cars);
        }
    }
}

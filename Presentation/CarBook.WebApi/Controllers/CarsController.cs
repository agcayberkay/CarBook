using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Features.CQRS.Handlers.CarHandlers;
using CarBook.Application.Features.CQRS.Queries.CaarQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly GetCarQueryHandler _getCarQueryHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly RemoveCarCommandHandler _deleteCarCommandHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetCarWithBrandQueryHandler _getCarWithBrandQueryHandler;
        private readonly GetLastFiveCarsWithBrandsQueryHandler _getLastFiveCarsWithBrandsQueryHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler,
            GetCarQueryHandler getCarQueryHandler,
            UpdateCarCommandHandler updateCarCommandHandler,
            RemoveCarCommandHandler deleteCarCommandHandler,
            GetCarWithBrandQueryHandler getCarWithBrandQueryHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler,
            GetLastFiveCarsWithBrandsQueryHandler getLastFiveCarsWithBrandsQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _getCarQueryHandler = getCarQueryHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _deleteCarCommandHandler = deleteCarCommandHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getCarWithBrandQueryHandler = getCarWithBrandQueryHandler;
            _getLastFiveCarsWithBrandsQueryHandler = getLastFiveCarsWithBrandsQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var value = await _getCarQueryHandler.Handle();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await _getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _createCarCommandHandler.Handle(command);
            return Ok("Araç Eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _deleteCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Araç Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _updateCarCommandHandler.Handle(command);
            return Ok("Araç Güncellendi.");
        }

        [HttpGet("GetCarWithBrand")]
        public IActionResult GetCarWithBrand()
        {
            var value =  _getCarWithBrandQueryHandler.Handle();
            return Ok(value);

        }

        [HttpGet("GetLastFiveCarsWithBrandsQueryHandler")]
        public IActionResult GetLastFiveCarsWithBrandsQueryHandler()
        {
            var value = _getLastFiveCarsWithBrandsQueryHandler.Handle();
            return Ok(value);

        }

    }
}

using Carseer.Project.BE.App.Services.VehicleServicees;
using Carseer.Project.BE.Domain.V1.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Carseer.Project.BE.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("makes")]
        public async Task<ActionResult> GetMakes()
        {
            var makes = await _vehicleService.GetMakesAsync();
            List<Make>? makeResponses = makes.Results?.ToList();
            return Ok(makeResponses);
        }

        [HttpGet("makes/{makeId}/types")]
        public async Task<ActionResult> GetVehicleTypes(int makeId)
        {
            var types = await _vehicleService.GetVehicleTypesForMakeAsync(makeId);
            List<VehicleType>? makeResponses = types.Results?.ToList();

            return Ok(makeResponses);
        }

    }
}

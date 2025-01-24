using Carseer.Project.BE.App.Services.VehicleServicees;
using Carseer.Project.BE.Domain.V1.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Carseer.Project.BE.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _integrationService;
        public VehiclesController(IVehicleService integrationService)
        {
            _integrationService = integrationService;
        }

        [HttpGet("makes")]
        public async Task<ActionResult> GetMakes()
        {
            var makes = await _integrationService.GetMakesAsync();
            return Ok(makes);
        }
    }
}

using Carseer.Project.BE.Domain.V1.Responses;

namespace Carseer.Project.BE.App.Services.VehicleServicees
{
    public interface IVehicleService
    {
        Task<MakeResponse> GetMakesAsync();
    }
}

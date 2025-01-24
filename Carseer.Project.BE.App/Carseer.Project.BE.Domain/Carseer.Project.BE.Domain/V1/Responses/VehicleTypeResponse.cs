namespace Carseer.Project.BE.Domain.V1.Responses
{
    public class VehicleTypeResponse
    {
        public long Count { get; set; }
        public string? Message { get; set; }

        public string? SearchCriteria { get; set; }
        public List<VehicleType>? Results { get; set; }

    }

    public class VehicleType
    {
        public long VehicleTypeId { get; set; }
        public string? VehicleTypeName { get; set; }
    }
}

namespace Carseer.Project.BE.Domain.V1.Responses
{
    public class VehicleModelResponse
    {
        public long Count { get; set; }
        public string? Message { get; set; }

        public string? SearchCriteria { get; set; }
        public List<VehicleModel>? Results { get; set; }
    }

    public class VehicleModel
    {
        public long Make_ID { get; set; }
        public long Model_ID { get; set; }
        public string Make_Name { get; set; } = default!;
        public string Model_Name { get; set; } = default!;
    }
}

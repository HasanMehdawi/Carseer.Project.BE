namespace Carseer.Project.BE.Domain.V1.Responses
{
    public class Make
    {
        public int Make_ID { get; set; }
        public string? Make_Name { get; set; }
    }

    public class MakeResponse
    {
        public int Count { get; set; }
        public string? Message { get; set; }
        public List<Make>? Results { get; set; }
    }
}

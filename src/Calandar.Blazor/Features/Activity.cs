namespace Calandar.Blazor.Features
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
    }
}

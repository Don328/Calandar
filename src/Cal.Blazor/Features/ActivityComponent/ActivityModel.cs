namespace Cal.Blazor.Features.ActivityComponent;

public class ActivityModel
{
    public ActivityModel(
        DateOnly date, 
        int id = 0)
    {
        Id = id;
        Date = date;
    }

    public int Id { get; }
    public DateOnly Date { get; }
    public TimeOnly Time { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}

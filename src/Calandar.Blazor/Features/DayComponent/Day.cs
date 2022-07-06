namespace Calandar.Blazor.Features.DayComponent
{
    public record Day(DateTime Date, IEnumerable<Activity> Activities);
}

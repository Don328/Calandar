using Cal.Blazor.Features.ActivityComponent;

namespace Cal.Blazor.Features.DayComponent
{
    public class DayModel
    {
        public DayModel(DateOnly date)
        {
            Date = date;
            Activities = new List<ActivityModel>();
        }

        public DateOnly Date { get; }
        public IEnumerable<ActivityModel> Activities { get; set; }
    }
}

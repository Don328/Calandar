using Cal.Shared.Features.Activities;

namespace Cal.Blazor.Features.DayComponent
{
    public class DayModel
    {
        public DayModel(DateOnly date)
        {
            Date = date;
            Activities = new List<ActivityDto>();
        }

        public DateOnly Date { get; }
        public IEnumerable<ActivityDto> Activities { get; set; }
    }
}

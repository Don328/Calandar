namespace Cal.Blazor.Features.DayComponent
{
    public class DayModel
    {
        public DayModel(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; }
    }
}

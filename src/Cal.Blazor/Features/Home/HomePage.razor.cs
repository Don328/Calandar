using Cal.Blazor.Features.DayComponent;
using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.Home
{
    public partial class HomePage : ComponentBase
    {
        private DayModel _today = new DayModel(new DateOnly(
                DateTime.Today.Year,
                DateTime.Today.Month,
                DateTime.Today.Day));

        private List<DayModel> OneWeekSchedule
            = new List<DayModel>();

        private DayModel _selectedDay = default!;
        private bool _showAddActivity = false;

        protected override async Task OnInitializedAsync()
        {
            for (int i = 0; i < 7; i++)
            {
                var date = _today.Date;
                OneWeekSchedule.Add(new DayModel(date.AddDays(i)));
            }

            await base.OnInitializedAsync();
        }

        private void HideAddActivity() => _showAddActivity = false;

        private void ShowAddActivity(DayModel day)
        {
            _showAddActivity = true;
            _selectedDay = day;
        }


        private void SubmitNewActivity()
        {

        }
    }
}

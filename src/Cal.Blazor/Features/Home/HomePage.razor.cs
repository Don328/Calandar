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

        private List<DayModel> _currentWeekSchedule
            = new();

        private List<DayModel> _currentMonthScheduel
            = new();

        private DayModel _selectedDay = default!;
        private bool _showAddActivity = false;

        protected override async Task OnInitializedAsync()
        {
            _selectedDay = _today;
            GetCurrentWeekSchedule();
            GetCurrentMonthSchdule();

            await base.OnInitializedAsync();
        }

        private void GetCurrentWeekSchedule()
        {
            var offset = -(int)_today.Date.DayOfWeek;

            for (int i = 0; i < 7; i++)
            {
                _currentWeekSchedule.Add(new DayModel(
                        _today.Date.AddDays(offset)));
                offset++;
            }
        }

        private void GetCurrentMonthSchdule()
        {
            var offset = -(int)_today.Date.Day +1;
            var day = new DayModel(
                _today.Date.AddDays(offset));
            var month = _today.Date.Month;

            while(day.Date.Month == month)
            {
                _currentMonthScheduel.Add(day);
                day = new DayModel(day.Date.AddDays(1));
            }
            
        }

        private void HideAddActivity() => _showAddActivity = false;

        private void ShowAddActivity(DayModel day)
        {
            _showAddActivity = true;
            _selectedDay = day;
        }

        private void SelectToday() => _selectedDay = _today;

        private void SelectDay(DayModel day)
        {
            _selectedDay = day;
        }

        private void SubmitNewActivity()
        {

        }
    }
}

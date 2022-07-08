using Cal.Blazor.Features.DayComponent;
using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.MonthComponent
{
    public partial class MonthView : ComponentBase
    {
        private DateOnly _cursor = default!;
        private List<List<DayModel>> _weeks = new();


        [Parameter, EditorRequired]
        public IEnumerable<DayModel> Days { get; set; }
            = new List<DayModel>();

        [Parameter, EditorRequired]
        public DayModel Today { get; set; } = default!;

        [Parameter, EditorRequired]
        public EventCallback<DayModel> OnShowAddTask { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _cursor = Today.Date;
            FindFirstSunday();
            LoadWeekBuffer();

            await base.OnInitializedAsync();
        }

        private void FindFirstSunday()
        {
            FindFirstWeek();

            int dayValue = (int)_cursor.DayOfWeek;

            if (dayValue > 1)
            {
                _cursor = _cursor.AddDays(- dayValue);
            }
        }

        private void FindFirstWeek()
        {
            if (_cursor.Day > 7)
            {
                _cursor = _cursor.AddDays(-7);
                FindFirstWeek();
            }
        }

        private void LoadWeekBuffer()
        {
            
            var week = new List<DayModel>();
            for (int i = 0; i < 7; i++)
            {
                week.Add(new DayModel(_cursor));
                _cursor = _cursor.AddDays(1);
            }

            _weeks.Add(week);

            if (_cursor.Month == Today.Date.Month)
            {
                LoadWeekBuffer();
            }

        }

        private async Task HandleShowAddTask(DayModel day)
        {
            await OnShowAddTask.InvokeAsync(day);
        }

    }
}

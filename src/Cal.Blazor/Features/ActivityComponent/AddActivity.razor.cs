using Cal.Shared.Features.Activities;
using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.ActivityComponent
{
    public partial class AddActivity : ComponentBase
    {
        private ActivityDto _activity = new();
        private bool _timeIsSet = false;
        private string _timeSectionError = "";

        [Parameter, EditorRequired]
        public EventCallback<ActivityDto> OnSubmit { get; set; }

        [Parameter, EditorRequired]
        public EventCallback OnCancel { get; set; }

        [Parameter, EditorRequired]
        public DateOnly Date { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _activity.Date = Date;
            await base.OnInitializedAsync();
        }

        private async Task HandleTimeSet(TimeOnly time)
        {
            _activity.Time = time;
            var hour = _activity.Time.Hour;
            var min = _activity.Time.Minute;
            _timeIsSet = true;

            await Task.CompletedTask;
        }

        private async Task Submit()
        {
            if (_timeIsSet)
            {
                _timeSectionError = "";
                await OnSubmit.InvokeAsync(_activity);
            }
            else
            {
                _timeSectionError = "Please select a time";
            }
        }

        private async Task Cancel()
        {
            await OnCancel.InvokeAsync();
        }
    }
}

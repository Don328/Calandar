using Cal.Shared.Features.Activities;
using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.ActivityComponent
{
    public partial class AddActivity : ComponentBase
    {
        private ActivityDto _activity = new();

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

            await Task.CompletedTask;
        }

        private async Task Submit()
        {
            await OnSubmit.InvokeAsync(_activity);
        }

        private async Task Cancel()
        {
            await OnCancel.InvokeAsync();
        }
    }
}

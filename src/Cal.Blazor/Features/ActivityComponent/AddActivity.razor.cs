using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.ActivityComponent
{
    public partial class AddActivity : ComponentBase
    {
        private ActivityModel _activity = default!;

        [Parameter, EditorRequired]
        public EventCallback<ActivityModel> OnSubmit { get; set; }

        [Parameter, EditorRequired]
        public EventCallback OnCancel { get; set; }

        [Parameter, EditorRequired]
        public DateOnly Date { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _activity = new(Date);
            await base.OnInitializedAsync();
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

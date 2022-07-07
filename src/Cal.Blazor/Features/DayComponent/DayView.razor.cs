using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.DayComponent;

public partial class DayView : ComponentBase
{
    [Parameter]
    public DayModel Day { get; set; } = default!;

    [Parameter]
    public EventCallback<DayModel> OnShowAddTask { get; set; }

    private async Task HandleShowAddTask()
    {
        await OnShowAddTask.InvokeAsync(Day);
    }
}

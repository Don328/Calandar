using Cal.Blazor.Features.DayComponent;
using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.WeekComponent;

public partial class WeekView : ComponentBase
{
    [Parameter, EditorRequired]
    public IEnumerable<DayModel> Days { get; set; } 
        = new List<DayModel>();

    [Parameter, EditorRequired]
    public EventCallback<DayModel> OnShowAddTask { get; set; }

    private async Task HandleShowAddTask(DayModel day)
    {
        await OnShowAddTask.InvokeAsync(day);
    }
}

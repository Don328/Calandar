using Cal.Blazor.Features.DayComponent;
using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.WeekComponent;

public partial class WeekView : ComponentBase
{
    [Parameter]
    public bool DisplayDateInfo { get; set; }
        = false;

    [Parameter, EditorRequired]
    public IEnumerable<DayModel> Days { get; set; } 
        = new List<DayModel>();

    [Parameter, EditorRequired]
    public EventCallback<DayModel> OnSubmit { get; set; }

    private async Task Submit(DayModel day)
    {
        await OnSubmit.InvokeAsync(day);
    }
}

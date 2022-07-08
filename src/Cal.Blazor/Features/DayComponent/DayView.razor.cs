using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.DayComponent;

public partial class DayView : ComponentBase
{
    private DateTime _today;

    [Parameter, EditorRequired]
    public DayModel Day { get; set; } = default!;

    [Parameter, EditorRequired]
    public EventCallback<DayModel> OnShowAddTask { get; set; }

    protected override void OnInitialized()
    {
        _today = DateTime.Today;
    }

    private async Task HandleShowAddTask()
    {
        await OnShowAddTask.InvokeAsync(Day);
    }

    private string DisplayAbriviatedDay(DayOfWeek day)
    {
        switch (day)
        {
            case DayOfWeek.Sunday:
                return "Sun";
            case DayOfWeek.Monday:
                return "Mon";
            case DayOfWeek.Tuesday:
                return "Tue";
            case DayOfWeek.Wednesday:
                return "Wed";
            case DayOfWeek.Thursday:
                return "Thu";
            case DayOfWeek.Friday:
                return "Fri";
            case DayOfWeek.Saturday:
                return "Sat";
            default: return "";
        }
    }
}

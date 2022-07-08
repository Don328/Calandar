using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.DayComponent;

public partial class DayView : ComponentBase
{
    private DateTime _today;

    [Parameter]
    public bool DisplayDayOfWeek { get; set; }
        = false;

    [Parameter]
    public bool DisplayMonth { get; set; }
        = false;

    [Parameter]
    public bool DisplayYear { get; set; } = false;


    [Parameter]
    public bool AlwayShowButton { get; set; } = false;

    [Parameter, EditorRequired]
    public string ButtonText { get; set; } = default!;

    [Parameter, EditorRequired]
    public string ToolTipText { get; set; } = default!;

    [Parameter, EditorRequired]
    public DayModel Day { get; set; } = default!;

    [Parameter, EditorRequired]
    public EventCallback<DayModel> OnSubmit { get; set; }

    protected override void OnInitialized()
    {
        _today = DateTime.Today;
    }

    private async Task Submit()
    {
        await OnSubmit.InvokeAsync(Day);
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

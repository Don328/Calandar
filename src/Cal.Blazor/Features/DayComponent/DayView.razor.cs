using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.DayComponent;

public partial class DayView : ComponentBase
{
    [Parameter]
    public DayModel Day { get; set; } = default!;
}

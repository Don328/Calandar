using Cal.Blazor.Features.DayComponent;
using Microsoft.AspNetCore.Components;

namespace Cal.Blazor.Features.Home
{
    public partial class HomePage : ComponentBase
    {
        private DayModel _today = new DayModel(DateTime.Today);


        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}

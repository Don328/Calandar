using Calandar.Blazor.Features.DayComponent;
using Microsoft.AspNetCore.Components;

namespace Calandar.Blazor.Features.Home
{
    public partial class HomePage : ComponentBase
    {
        private DateTime _today = DateTime.Today;
        private ViewMode _viewMode = ViewMode.CurrentYear;
        private IEnumerable<Day> Days = default!;

        protected override async Task OnInitializedAsync()
        {
            await SelectViewMode();
        }

        private async Task SelectViewMode()
        {
 
            var builder = new CalandarBuilder(
                CalandarBuilder.IncrementSize.Day);
            
            switch (_viewMode)
            {
                case ViewMode.CurrentYear:
                    builder.Increment =
                        CalandarBuilder.IncrementSize
                            .EndOfYear;
                    builder.IncrementValue = 0;
                    Days = await builder.Build();
                    break;
                case ViewMode.CurrentMonth:
                    builder.Increment =
                        CalandarBuilder.IncrementSize
                            .CurrentMonth;
                    builder.IncrementValue = 0;
                    Days = await builder.Build();
                    break;
                case ViewMode.CurrentWeek:
                    builder.Increment =
                        CalandarBuilder
                        .IncrementSize.Day;
                    builder.IncrementValue = 6;
                    Days = await builder.Build();
                    break;
                case ViewMode.RollingSix:
                    builder.Increment =
                        CalandarBuilder
                        .IncrementSize.Month;
                    builder.IncrementValue = 5;
                    Days = await builder.Build();
                    break;
                case ViewMode.RollingTwelve:
                    builder.Increment =
                        CalandarBuilder
                        .IncrementSize.Month;
                    builder.IncrementValue = 11;
                    Days = await builder.Build();
                    break;
                case ViewMode.RollingThree:
                    builder.Increment =
                        CalandarBuilder
                        .IncrementSize.Month;
                    builder.IncrementValue = 2;
                    Days = await builder.Build();
                    break;
                case ViewMode.SelectedDay:
                    // View Selected Day
                    break;
                case ViewMode.SelectedMonth:
                    // View Selected Month
                    break;
                case ViewMode.SelectedWeek:
                    // Veiw Selected Week
                    break;
                case ViewMode.SelectedYear:
                    // Veiw Selected Year
                    break;
                case ViewMode.Today:
                    // View Selected Day(Today)
                    break;
                case ViewMode.TwoWeeks:
                    builder.Increment =
                        CalandarBuilder
                            .IncrementSize.Day;
                    builder.IncrementValue = 13;
                    Days = await builder.Build();
                    break;
                default:
                    _viewMode = ViewMode.CurrentYear;
                    await SelectViewMode();
                    break;
            }
        }
    }
}

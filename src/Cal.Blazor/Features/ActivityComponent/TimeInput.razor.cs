using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace Cal.Blazor.Features.ActivityComponent
{
    public partial class TimeInput: ComponentBase
    {
        private List<int> _hours = new();
        private List<int> _minutes = new();
        private int _hour;
        private int _min;

        private bool _pm = false;

        private TimeOnly _time = new();

        [Parameter, EditorRequired]
        public EventCallback<TimeOnly> OnTimeSet { get; set; }

        protected override Task OnParametersSetAsync()
        {
            GetHoursList();
            GetMinutesList();

            return base.OnParametersSetAsync();
        }

        private async Task TogglePM()
        {
            _pm = !_pm;
            await HandleTimeSet();
        }

        private async Task HandleTimeSet()
        {
            var hour = _hour;
            if (_pm)
            {
                hour += 12;
            }
            _time = new TimeOnly
                (hour: hour, minute: _min);
            await OnTimeSet.InvokeAsync(_time);
        }

        private void GetHoursList()
        {
            for(int i = 1; i < 13; i++)
            {
                _hours.Add(i);
            }
        }

        private void GetMinutesList()
        {
            for(int i = 0; i < 60; i+=5)
            {
                _minutes.Add(i);
            }
        }
    }
}

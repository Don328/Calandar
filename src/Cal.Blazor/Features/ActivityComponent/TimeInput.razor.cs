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
        private bool _hourIsSet;
        private bool _minuteIsSet;
        private bool _isPM = false;

        private TimeOnly _time = new();

        [Parameter, EditorRequired]
        public string ErrorMessage { get; set; } = "";

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
            _isPM = !_isPM;
            if (_hourIsSet && _minuteIsSet)
            {
                await HandleTimeSet();
            }
        }

        private async Task HandleHourSet()
        {
            _hourIsSet = true;
            if (_minuteIsSet)
            {
                await HandleTimeSet();
            }
        }

        private async Task HandleMinuteSet()
        {
            _minuteIsSet = true;
            if(_hourIsSet)
            {
                await HandleTimeSet();
            }
        }

        private async Task HandleTimeSet()
        {
            var hour = _hour;
            if (_isPM)
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

using Calandar.Blazor.Features.DayComponent;

namespace Calandar.Blazor.Features.Home
{
    public class CalandarBuilder
    {
        public enum IncrementSize
        {
            EndOfYear,
            CurrentMonth,
            Year,
            Month,
            Day,
        }
        public IncrementSize Increment { get; set; }
        public int IncrementValue { get; set; }

        private DateTime _today = DateTime.Today;
        private delegate DateTime SetEndDate(int val);
        private SetEndDate _endDate;

        private DateTime AddYears(int val) =>
            _today.AddYears(val);
        private DateTime AddMonths(int val) =>
            _today.AddMonths(val);
        private DateTime AddDays(int val) => 
            _today.AddDays(val);
        private DateTime GetEndOfYear(int val) => 
            new DateTime(
                year: _today.Year + 1,
                month: 1,
                day: 1);

        public CalandarBuilder(
            IncrementSize incrementSize,
            int incrementValue = 0)
        {
            Increment = incrementSize;
            IncrementValue = incrementValue;

            switch (Increment)
            {
                case IncrementSize.EndOfYear:
                    _endDate = GetEndOfYear;
                    break;
                case IncrementSize.Year:
                    _endDate = AddYears;
                    break;
                case IncrementSize.Month:
                    _endDate = AddMonths;
                    break;
                case IncrementSize.Day:
                    _endDate = AddDays;
                    break;
                default:
                    _endDate = AddYears;
                    break;
            }
        }

        public async Task<IEnumerable<Day>> Build()
        {
            return await GetDays();
        }

        private async Task<IEnumerable<Day>> GetDays()
        {
            List<Day> days = new();
            var cursor = _today;

            while (cursor < _endDate(IncrementValue))
            {
                await AddDayToList(days, cursor);
                cursor.AddDays(1);
            }


            return await Task.FromResult(days);
        }

        private async Task AddDayToList(List<Day> days, DateTime date)
        {
            var day = new Day(
                date,
                new List<Activity>());
            days.Add(day);
            await Task.CompletedTask;
        }
    }
}

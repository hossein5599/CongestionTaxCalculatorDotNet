using CongestionTaxCalculatorDotNet.Interfaces;

namespace CongestionTaxCalculatorDotNet.Services;

public class TollFreeDays : ITollFreeDays
{
    private readonly HashSet<DateTime> _tollFreeDates = new();

    public TollFreeDays()
    {
        SetTollFreeDates();
    }

    private void SetTollFreeDates()
    {
        var startYear = 2013;
        var endYear = DateTime.Now.Year;

        for (var year = startYear; year <= endYear; year++)
        {
            for (var month = 1; month <= 12; month++)
            {
                var daysInMonth = DateTime.DaysInMonth(year, month);
                for (var day = 1; day <= daysInMonth; day++)
                {
                    DateTime currentDate = new(year, month, day);
                    if (IsTollFreeDate(currentDate))
                    {
                        _tollFreeDates.Add(currentDate);
                    }
                }
            }
        }
    }

    private bool IsTollFreeDate(DateTime date) =>
        date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday || IsHoliday(date);

    private bool IsHoliday(DateTime date) =>
        date.Year switch
        {
            2013 => IsHoliday2013(date),
            _ => false // No holidays defined for other years yet
        };

    private bool IsHoliday2013(DateTime date) =>
        date.Month == 1 && date.Day == 1 ||
        date.Month == 3 && (date.Day == 28 || date.Day == 29) ||
        date.Month == 4 && (date.Day == 1 || date.Day == 30) ||
        date.Month == 5 && (date.Day == 1 || date.Day == 8 || date.Day == 9) ||
        date.Month == 6 && (date.Day == 5 || date.Day == 6 || date.Day == 21) ||
        date.Month == 7 || // days in July
        date.Month == 11 && date.Day == 1 ||
        date.Month == 12 && (date.Day == 24 || date.Day == 25 || date.Day == 26 || date.Day == 31);

    public HashSet<DateTime> GetTollFreeDates() => new HashSet<DateTime>(_tollFreeDates);
}

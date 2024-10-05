using CongestionTaxCalculatorDotNet.Entities;
using CongestionTaxCalculatorDotNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CongestionTaxCalculatorDotNet.Services;

public class CongestionTaxCalculator : ICongestionTaxCalculator
{
    private readonly List<TaxRule> _taxRules;
    private readonly HashSet<DateTime> _tollFreeDates;
    private const int MaxDailyFee = 60;
    public CongestionTaxCalculator(List<TaxRule> taxRules, HashSet<DateTime> tollFreeDates)
    {
        _taxRules = taxRules;
        _tollFreeDates = tollFreeDates;
    }

    public long GetTax(IVehicle vehicle, DateTime[] dates)
    {
        if (vehicle.IsTollFree() || dates == null || dates.Length == 0)
        {
            return 0;
        }

        // grouping dates by day
        var groupedDates = dates
            .Where(date => !IsTollFreeDate(date))
            .GroupBy(date => date.Date);

        var totalFee = 0;

        foreach (var group in groupedDates)
        {
            var dailyFee = CalculateDailyTaxFee(group.ToArray());
            totalFee += dailyFee;
        }

        return totalFee;
    }
    private int CalculateDailyTaxFee(DateTime[] dailyDates)
    {
        Array.Sort(dailyDates);
        var dailyFee = 0;
        var maxFeeInInterval = 0;
        var intervalStart = dailyDates[0];

        foreach (var date in dailyDates)
        {
            if ((date - intervalStart).TotalMinutes <= 60)
            {
                int currentFee = GetTollFee(date);
                if (currentFee > maxFeeInInterval)
                {
                    maxFeeInInterval = currentFee;
                }
            }
            else
            {
                dailyFee += maxFeeInInterval;
                intervalStart = date;
                maxFeeInInterval = GetTollFee(date);
            }
        }

        dailyFee += maxFeeInInterval;
        return Math.Min(dailyFee, MaxDailyFee);
    }

    private int GetTollFee(DateTime date)
    {
        var time = date.TimeOfDay;
        return _taxRules.FirstOrDefault(rule =>
            time >= rule.StartTime && time < rule.EndTime)?.Amount ?? 0;
    }
    private bool IsTollFreeDate(DateTime date)
    {
        return _tollFreeDates.Contains(date.Date) ||
               date.DayOfWeek == DayOfWeek.Saturday ||
               date.DayOfWeek == DayOfWeek.Sunday;
    }

}


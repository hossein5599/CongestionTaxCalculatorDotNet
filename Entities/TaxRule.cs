namespace CongestionTaxCalculatorDotNet.Entities;
public class TaxRule
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int Amount { get; set; }
}


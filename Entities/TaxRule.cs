using System.ComponentModel.DataAnnotations;

namespace CongestionTaxCalculatorDotNet.Entities;
public class TaxRule
{
    [Key]
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int Amount { get; set; }
}


using CongestionTaxCalculatorDotNet.Entities;
namespace CongestionTaxCalculatorDotNet.Repositories;
public class TaxRuleRepository
{
    public List<TaxRule> LoadTaxRules(string filePath)
    {
        // hardcoded values could be replaced with datas from external sql
        return new List<TaxRule>
            {
                new TaxRule { StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(6, 30, 0), Amount = 8 },
                new TaxRule { StartTime = new TimeSpan(6, 30, 0), EndTime = new TimeSpan(7, 0, 0), Amount = 13 },
                new TaxRule { StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(8, 0, 0), Amount = 18 },
                new TaxRule { StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), Amount = 13 },
                new TaxRule { StartTime = new TimeSpan(8, 30, 0), EndTime = new TimeSpan(15, 0, 0), Amount = 8 },
                new TaxRule { StartTime = new TimeSpan(15, 0, 0), EndTime = new TimeSpan(15, 30, 0), Amount = 13 },
                new TaxRule { StartTime = new TimeSpan(15, 30, 0), EndTime = new TimeSpan(17, 0, 0), Amount = 18 },
                new TaxRule { StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(17, 30, 0), Amount = 13 },
                new TaxRule { StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(18, 30, 0), Amount = 8 },
                new TaxRule { StartTime = new TimeSpan(18, 30, 0), EndTime = new TimeSpan(24, 0, 0), Amount = 0 }
            };
    }
}


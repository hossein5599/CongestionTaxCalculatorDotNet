using CongestionTaxCalculatorDotNet.Contexts;
using CongestionTaxCalculatorDotNet.Entities;
namespace CongestionTaxCalculatorDotNet.Repositories;
public class TaxRuleRepository
{
    private readonly ApplicationDbContext _context;

    public TaxRuleRepository(ApplicationDbContext context)
    {
        _context = context;
        SeedData(); 
    }
    public List<TaxRule> LoadTaxRules() => _context.TaxRules.ToList();//using database
    // LoadTaxRulesHasrdCodes(""); // to use hardcodes

    private void SeedData()
    {
        if (!_context.TaxRules.Any())
        {
            var rules = new List<TaxRule>
            {
                new TaxRule { StartTime = DateTime.Today.AddHours(6).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(6).AddMinutes(30).AddSeconds(0), Amount = 8 },
                new TaxRule { StartTime = DateTime.Today.AddHours(6).AddMinutes(30).AddSeconds(0), EndTime = DateTime.Today.AddHours(7).AddMinutes(30).AddSeconds(0), Amount = 13 },
                new TaxRule { StartTime = DateTime.Today.AddHours(7).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(8).AddMinutes(30).AddSeconds(0), Amount = 18 },
                new TaxRule { StartTime = DateTime.Today.AddHours(8).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(8).AddMinutes(30).AddSeconds(0), Amount = 13 },
                new TaxRule { StartTime = DateTime.Today.AddHours(8).AddMinutes(30).AddSeconds(0), EndTime = DateTime.Today.AddHours(15).AddMinutes(30).AddSeconds(0), Amount = 8 },
                new TaxRule { StartTime = DateTime.Today.AddHours(15).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(15).AddMinutes(30).AddSeconds(0), Amount = 13 },
                new TaxRule { StartTime = DateTime.Today.AddHours(15).AddMinutes(30).AddSeconds(0), EndTime = DateTime.Today.AddHours(17).AddMinutes(0).AddSeconds(0), Amount = 18 },
                new TaxRule { StartTime = DateTime.Today.AddHours(17).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(17).AddMinutes(30).AddSeconds(0), Amount = 13 },
                new TaxRule { StartTime = DateTime.Today.AddHours(18).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(18).AddMinutes(30).AddSeconds(0), Amount = 8 },
                new TaxRule { StartTime = DateTime.Today.AddHours(18).AddMinutes(30).AddSeconds(0), EndTime = DateTime.Today.AddDays(1), Amount = 0 },
             
            };

            _context.TaxRules.AddRange(rules);
            _context.SaveChanges();
        }
    }

    public List<TaxRule> LoadTaxRulesHasrdCodes(string filePath)
    {
        // hardcoded values could be replaced with datas from external sql
        return new List<TaxRule>
            {
                new TaxRule { StartTime = DateTime.Today.AddHours(6).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(6).AddMinutes(30).AddSeconds(0), Amount = 8 },
                new TaxRule { StartTime = DateTime.Today.AddHours(6).AddMinutes(30).AddSeconds(0), EndTime = DateTime.Today.AddHours(7).AddMinutes(30).AddSeconds(0), Amount = 13 },
                new TaxRule { StartTime = DateTime.Today.AddHours(7).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(8).AddMinutes(30).AddSeconds(0), Amount = 18 },
                new TaxRule { StartTime = DateTime.Today.AddHours(8).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(8).AddMinutes(30).AddSeconds(0), Amount = 13 },
                new TaxRule { StartTime = DateTime.Today.AddHours(8).AddMinutes(30).AddSeconds(0), EndTime = DateTime.Today.AddHours(15).AddMinutes(30).AddSeconds(0), Amount = 8 },
                new TaxRule { StartTime = DateTime.Today.AddHours(15).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(15).AddMinutes(30).AddSeconds(0), Amount = 13 },
                new TaxRule { StartTime = DateTime.Today.AddHours(15).AddMinutes(30).AddSeconds(0), EndTime = DateTime.Today.AddHours(17).AddMinutes(0).AddSeconds(0), Amount = 18 },
                new TaxRule { StartTime = DateTime.Today.AddHours(17).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(17).AddMinutes(30).AddSeconds(0), Amount = 13 },
                new TaxRule { StartTime = DateTime.Today.AddHours(18).AddMinutes(0).AddSeconds(0), EndTime = DateTime.Today.AddHours(18).AddMinutes(30).AddSeconds(0), Amount = 8 },
                new TaxRule { StartTime = DateTime.Today.AddHours(18).AddMinutes(30).AddSeconds(0), EndTime = DateTime.Today.AddDays(1), Amount = 0 },
             

                //new TaxRule { StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(6, 30, 0), Amount = 8 },
                //new TaxRule { StartTime = new TimeSpan(6, 30, 0), EndTime = new TimeSpan(7, 0, 0), Amount = 13 },
                //new TaxRule { StartTime = new TimeSpan(7, 0, 0), EndTime = new TimeSpan(8, 0, 0), Amount = 18 },
                //new TaxRule { StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), Amount = 13 },
                //new TaxRule { StartTime = new TimeSpan(8, 30, 0), EndTime = new TimeSpan(15, 0, 0), Amount = 8 },
                //new TaxRule { StartTime = new TimeSpan(15, 0, 0), EndTime = new TimeSpan(15, 30, 0), Amount = 13 },
                //new TaxRule { StartTime = new TimeSpan(15, 30, 0), EndTime = new TimeSpan(17, 0, 0), Amount = 18 },
                //new TaxRule { StartTime = new TimeSpan(17, 0, 0), EndTime = new TimeSpan(17, 30, 0), Amount = 13 },
                //new TaxRule { StartTime = new TimeSpan(18, 0, 0), EndTime = new TimeSpan(18, 30, 0), Amount = 8 },
                //new TaxRule { StartTime = new TimeSpan(18, 30, 0), EndTime = new TimeSpan(24, 0, 0), Amount = 0 }
            };
    }
}


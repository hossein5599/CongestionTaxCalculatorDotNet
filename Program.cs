using CongestionTaxCalculatorDotNet.Entities;
using CongestionTaxCalculatorDotNet.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CongestionTaxCalculatorDotNet.Interfaces;
using CongestionTaxCalculatorDotNet.Contexts;
using CongestionTaxCalculatorDotNet.Services;

string[] dateStrings = {
            "2013-01-01 7:30:00",
            "2013-01-02 7:30:00",
            "2013-01-02 8:10:00",
            "2013-01-02 8:20:00",
            "2013-01-02 15:10:00",
            "2013-01-14 21:00:00",
            "2013-01-15 21:00:00",
            "2013-02-07 06:23:27",
            "2013-02-07 15:27:00",
            "2013-02-08 06:27:00",
            "2013-02-08 06:20:27",
            "2013-02-08 14:35:00",
            "2013-02-08 15:29:00",
            "2013-02-08 15:47:00",
            "2013-02-08 16:01:00",
            "2013-02-08 16:48:00",
            "2013-02-08 17:49:00",
            "2013-02-08 18:29:00",
            "2013-02-08 18:35:00",
            "2013-03-26 14:25:00",
            "2013-03-28 14:07:27"
        };

var dates = new DateTime[dateStrings.Length]; // Initialize the dates array

// converting strings to DateTime and store them in the dates array
for (var i = 0; i < dateStrings.Length; i++)
{
    dates[i] = DateTime.Parse(dateStrings[i]); 
    Console.WriteLine(dates[i].ToString("yyyy-MM-dd HH:mm:ss")); 
}

var services = new ServiceCollection();

// preparing data for tax rules and toll free dates.
var rulesRepo = new TaxRuleRepository();
var taxRules = rulesRepo.LoadTaxRules("example-path");


//adding dependency injections 
services.AddSingleton<ITollFreeDays, TollFreeDays>();
services.AddTransient<TollCalculatorContext>();
services.AddSingleton<ICongestionTaxCalculator>(provider =>
{
    var tollFreeDays = provider.GetService<ITollFreeDays>();
    return new CongestionTaxCalculator(taxRules, tollFreeDays.GetTollFreeDates());
});

var serviceProvider = services.BuildServiceProvider();

// creating a specific vehicle instance
var car = new Car();

// get the congestion tax calculator from the service provider
var congestionTaxCalculator = serviceProvider.GetService<ICongestionTaxCalculator>();

// creating the TollCalculatorContext with the specific vehicle
var context = new TollCalculatorContext(congestionTaxCalculator, car);


// calculating the tax
var tax = context.CalculateTax(dates);
Console.WriteLine($"Total tax for the vehicle: {tax}"); //Total tax for the vehicle: 120

Console.ReadKey();
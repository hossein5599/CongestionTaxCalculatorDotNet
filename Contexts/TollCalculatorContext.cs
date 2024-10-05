using CongestionTaxCalculatorDotNet.Interfaces;

namespace CongestionTaxCalculatorDotNet.Contexts;

public class TollCalculatorContext
{
    private readonly ICongestionTaxCalculator _calculator;
    private IVehicle _vehicle;

    public TollCalculatorContext(ICongestionTaxCalculator calculator, IVehicle vehicle)
    {
        _calculator = calculator;
        _vehicle = vehicle;
    }

    public void SetVehicle(IVehicle vehicle)
    {
        _vehicle = vehicle;
    }

    // calculating the congestion tax based on the vehicle type
    public long CalculateTax(DateTime[] dates)
    {
        return _calculator.GetTax(_vehicle, dates);
    }

    public bool IsTollFreeVehicle()
    {
        // using the IVehicle implementation to check toll free status
        return _vehicle.IsTollFree();
    }
}

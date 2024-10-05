namespace CongestionTaxCalculatorDotNet.Interfaces;
public interface ICongestionTaxCalculator
{
    long GetTax(IVehicle vehicle, DateTime[] dates);
}

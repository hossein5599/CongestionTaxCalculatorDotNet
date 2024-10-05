using CongestionTaxCalculatorDotNet.Interfaces;
namespace CongestionTaxCalculatorDotNet.Entities;
public class Motorcycle : IVehicle
{
    public bool IsTollFree() => true;
}


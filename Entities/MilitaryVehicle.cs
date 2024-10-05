using CongestionTaxCalculatorDotNet.Interfaces;
namespace CongestionTaxCalculatorDotNet.Entities;
public class MilitaryVehicle : IVehicle
{
    public bool IsTollFree() => true;
}


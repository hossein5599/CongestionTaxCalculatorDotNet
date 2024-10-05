using CongestionTaxCalculatorDotNet.Interfaces;
namespace CongestionTaxCalculatorDotNet.Entities;
public class Tractor : IVehicle
{
    public bool IsTollFree() => true;

}


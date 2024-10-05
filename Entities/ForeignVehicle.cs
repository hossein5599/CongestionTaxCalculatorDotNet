using CongestionTaxCalculatorDotNet.Interfaces;
namespace CongestionTaxCalculatorDotNet.Entities;
public class ForeignVehicle : IVehicle
{
    public bool IsTollFree() => true;
}


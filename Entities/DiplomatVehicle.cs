using CongestionTaxCalculatorDotNet.Interfaces;
namespace CongestionTaxCalculatorDotNet.Entities;
public class DiplomatVehicle : IVehicle
{
    public bool IsTollFree() => true;
}


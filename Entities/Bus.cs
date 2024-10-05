using CongestionTaxCalculatorDotNet.Interfaces;
namespace CongestionTaxCalculatorDotNet.Entities;
public class Bus: IVehicle
{
    // buses are not free
    public bool IsTollFree() => false;
}


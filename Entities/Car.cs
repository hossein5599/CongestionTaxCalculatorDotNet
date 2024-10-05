using CongestionTaxCalculatorDotNet.Interfaces;
namespace CongestionTaxCalculatorDotNet.Entities;
public class Car : IVehicle
{
    // cars are not free
    public bool IsTollFree() => false; 
}


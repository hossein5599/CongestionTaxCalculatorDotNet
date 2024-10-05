using CongestionTaxCalculatorDotNet.Interfaces;
namespace CongestionTaxCalculatorDotNet.Entities;
public class EmergencyVehicle : IVehicle
{
    public bool IsTollFree() => true;
}


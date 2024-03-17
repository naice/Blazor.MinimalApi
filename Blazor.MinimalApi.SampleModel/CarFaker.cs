using Bogus;

namespace Blazor.MinimalApi.Model;

public sealed class CarFaker : Faker<Car>
{
    public CarFaker()
    {
        CustomInstantiator(f => new Car(
            f.Vehicle.Vin(),
            f.Vehicle.Fuel(), 
            f.Vehicle.Model(), 
            f.Vehicle.Manufacturer(),
            f.Vehicle.Type()));
    }
}
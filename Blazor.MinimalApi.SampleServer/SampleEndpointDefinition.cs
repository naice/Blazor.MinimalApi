using Blazor.MinimalApi.Model;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.MinimalApi.Server;


public class SampleEndpointDefinition : IEndpointDefinition
{
    public void DefineEndpoints(IEndpointRouteBuilder builder)
    {
        builder.MinimalMapGet<Car[]>(async ([FromQuery(Name = "count")] int count) =>
        {
            await Task.Delay(100);
            return new CarFaker().Generate(count);
        });
        builder.MinimalMapGet<CarsRequest, Car[]>((CarsRequest request) 
            => new CarFaker().Generate(request.Count));
        builder.MinimalMapQuery<CarsRequest, Car[]>((CarsRequest request) 
            => new CarFaker().Generate(request.Count));
    }
}
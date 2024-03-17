
using Microsoft.AspNetCore.Routing;
namespace Blazor.MinimalApi;

public interface IEndpointDefinition
{
    public void DefineEndpoints(IEndpointRouteBuilder builder);
}
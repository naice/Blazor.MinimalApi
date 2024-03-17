using Blazor.MinimalApi.Abstractions;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.MinimalApi;

public static class MinimalApiEndpointDefinitionExtensions
{
    private static readonly Type _iEndpointDefinitionType = typeof(IEndpointDefinition);

    public static void AddEndpointDefinitions(this IServiceCollection services, params Type[] assemblyTargets)
    {
        var endpointDefinitions = assemblyTargets
                .Select(at => at.Assembly)
                .Distinct()
                .SelectMany(a => a.GetTypes().Where(
                    t => t.IsAssignableTo(_iEndpointDefinitionType) && 
                         t is { IsInterface: false, IsAbstract: false }));
        services.AddSingleton<IMinimalApiRouteProvider, MinimalApiDefaultRouteProvider>();
        services.AddSingleton(new EndpointDefinitions(endpointDefinitions));
    }

    public static void UseEndpointDefinitions(this IEndpointRouteBuilder endpointBuilder)
    {
        var serviceProvider = endpointBuilder.ServiceProvider;
        foreach (var type in serviceProvider.GetRequiredService<EndpointDefinitions>())
        {
            ((IEndpointDefinition)ActivatorUtilities.CreateInstance(serviceProvider, type))
                .DefineEndpoints(endpointBuilder);
        }
    }
}

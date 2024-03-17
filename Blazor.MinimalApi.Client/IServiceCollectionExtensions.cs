using Blazor.MinimalApi.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.MinimalApi.Client;

public static class IServiceCollectionExtensions
{
    public static void AddMinimapApiClient(this IServiceCollection services)
    {
        services.AddSingleton<IMinimalApiRouteProvider, MinimalApiDefaultRouteProvider>();
        services.AddScoped(typeof(MinimalHttpClient<>));
        services.AddScoped(typeof(MinimalHttpClient<,>));
    }
}

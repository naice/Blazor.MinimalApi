using Blazor.MinimalApi.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Blazor.MinimalApi;

public static class MinimalApiServerExtensions
{
    public static IMinimalApiRouteProvider GetMinimalApiRouteProvider(this IEndpointRouteBuilder endpointRouteBuilder) =>
        endpointRouteBuilder.ServiceProvider.GetService<IMinimalApiRouteProvider>() ?? 
        throw new InvalidOperationException($"{nameof(IMinimalApiRouteProvider)} missing.");
    
    #region RequestDelegate TRequest TResponse
    public static IEndpointConventionBuilder MinimalMap<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, string type, RequestDelegate requestDelegate)
    {
        var routeProvider = builder.GetMinimalApiRouteProvider();
        return builder.MapPost(
            routeProvider.GetRoute(type, new []{ typeof(TRequest), typeof(TResponse) }),
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapCreate<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Create,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapUpdate<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Update,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapCreateOrUpdate<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.CreateOrUpdate,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapDelete<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Delete,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapFetch<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Fetch,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapQuery<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Query,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapGet<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Get,
            requestDelegate);
    }
    #endregion
    
    #region RequestDelegate TRequest
    public static IEndpointConventionBuilder MinimalMap<TRequest>(
        this IEndpointRouteBuilder builder, string type, RequestDelegate requestDelegate)
    {
        var routeProvider = builder.GetMinimalApiRouteProvider();
        return builder.MapPost(
            routeProvider.GetRoute(type, new []{ typeof(TRequest) }), 
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapCreate<TRequest>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Create,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapUpdate<TRequest>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Update,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapCreateOrUpdate<TRequest>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.CreateOrUpdate,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapDelete<TRequest>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Delete,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapFetch<TRequest>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Fetch,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapQuery<TRequest>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Query,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapGet<TRequest>(
        this IEndpointRouteBuilder builder, RequestDelegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Get,
            requestDelegate);
    }
    #endregion
    
    #region Delegate TRequest TResponse
    public static RouteHandlerBuilder MinimalMap<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, string type, Delegate handler)
    {
        var routeProvider = builder.GetMinimalApiRouteProvider();
        var pattern = routeProvider.GetRoute(type, new[] { typeof(TRequest), typeof(TResponse) }); 
        return builder.MapPost(pattern, handler);
    }
    
    public static IEndpointConventionBuilder MinimalMapCreate<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Create,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapUpdate<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Update,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapCreateOrUpdate<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.CreateOrUpdate,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapDelete<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Delete,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapFetch<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Fetch,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapQuery<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Query,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapGet<TRequest, TResponse>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest, TResponse>(
            MinimalApiMethodCatalog.Get,
            requestDelegate);
    }
    #endregion
    
    #region Delegate TRequest
    public static RouteHandlerBuilder MinimalMap<TRequest>(
        this IEndpointRouteBuilder builder, string type, Delegate handler)
    {
        var routeProvider = builder.GetMinimalApiRouteProvider();
        return builder.MapPost(
            routeProvider.GetRoute(type, new []{ typeof(TRequest) }), 
            handler);
    }
    
    public static IEndpointConventionBuilder MinimalMapCreate<TRequest>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Create,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapUpdate<TRequest>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Update,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapCreateOrUpdate<TRequest>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.CreateOrUpdate,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapDelete<TRequest>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Delete,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapFetch<TRequest>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Fetch,
            requestDelegate);
    }
    
    public static IEndpointConventionBuilder MinimalMapQuery<TRequest>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Query,
            requestDelegate);
    }
    public static IEndpointConventionBuilder MinimalMapGet<TRequest>(
        this IEndpointRouteBuilder builder, Delegate requestDelegate)
    {
        return builder.MinimalMap<TRequest>(
            MinimalApiMethodCatalog.Get,
            requestDelegate);
    }
    #endregion 
}
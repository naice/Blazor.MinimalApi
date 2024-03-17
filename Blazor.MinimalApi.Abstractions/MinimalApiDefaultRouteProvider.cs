namespace Blazor.MinimalApi.Abstractions;

public class MinimalApiDefaultRouteProvider : IMinimalApiRouteProvider
{
    public string GetRoute(string type, Type[] types, string? query = null)
    {
        var route = $"api/{type}/" + string.Join("/", types.Select(x => x.Name));
        
        if (query != null)
            route += "?" + query;
        return route;
    }
}

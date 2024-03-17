namespace Blazor.MinimalApi.Abstractions;

public interface IMinimalApiRouteProvider
{
    public string GetRoute(string type, Type[] types, string? query = null);
}

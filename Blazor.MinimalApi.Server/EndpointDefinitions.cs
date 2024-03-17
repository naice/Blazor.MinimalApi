namespace Blazor.MinimalApi;

public class EndpointDefinitions(IEnumerable<Type> types) : List<Type>(types);

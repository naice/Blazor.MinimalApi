namespace Blazor.MinimalApi.Client;

public record QueryParameters()
{
    public List<QueryParameter> Parameters { get; } = [];


    public QueryParameters With(string name, object? value)
    {
        Parameters.Add(new QueryParameter(name, value));
        return this;
    }

    public override string ToString()
        => string.Join("&", Parameters.Select(p => $"{p.Name}={p.Value ?? ""}"));
    
    public static implicit operator string(QueryParameters queryParameters)
    {
        return queryParameters.ToString();
    }
}
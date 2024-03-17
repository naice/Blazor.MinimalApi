using System.Net.Http.Json;
using System.Text.Json;
using Blazor.MinimalApi.Abstractions;

namespace Blazor.MinimalApi.Client;

public class MinimalHttpClient<TEntity>(
    HttpClient http,
    IMinimalApiRouteProvider routeProvider)
{
    private readonly Type[] _types = [typeof(TEntity)];

    protected virtual Task BeforeSend(HttpRequestMessage requestMessage) => Task.CompletedTask;

    public HttpRequestMessage CreateHttpRequestMessage(string type, string? query = null)
        => new (HttpMethod.Post, routeProvider.GetRoute(type, _types, query));

    public async Task<TEntity?> SendAndReceiveJson(string type, TEntity value, 
        JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        var httpResponse = await SendJson(type, value, options, query, cancellationToken);
        return await httpResponse.Content.ReadFromJsonAsync<TEntity>(cancellationToken: cancellationToken);
    }
    
    public async Task<HttpResponseMessage> SendJson(string type, TEntity value,
        JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        var requestMessage = CreateHttpRequestMessage(type, query);
        var content = JsonContent.Create(value, mediaType: null, options);
        requestMessage.Content = content;
        await BeforeSend(requestMessage);
        var httpResponse = await http.SendAsync(requestMessage, cancellationToken);
        return httpResponse;
    }
    
    public async Task<TEntity?> ReceiveJson(string type,
        JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        var requestMessage = CreateHttpRequestMessage(type, query);
        await BeforeSend(requestMessage);
        var httpResponse = await http.SendAsync(requestMessage, cancellationToken);
        return await httpResponse.Content.ReadFromJsonAsync<TEntity>(cancellationToken: cancellationToken);
    }
    
    public Task<TEntity?> Create(TEntity value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return SendAndReceiveJson(MinimalApiMethodCatalog.Create, value, options, query, cancellationToken);
    }
    public Task<TEntity?> CreateOrUpdate(TEntity value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return SendAndReceiveJson(MinimalApiMethodCatalog.CreateOrUpdate, value, options, query, cancellationToken);
    }
    public Task<TEntity?> Delete(TEntity value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return SendAndReceiveJson(MinimalApiMethodCatalog.Delete, value, options, query, cancellationToken);
    }
    public Task<TEntity?> Fetch(TEntity value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return SendAndReceiveJson(MinimalApiMethodCatalog.Fetch, value, options, query, cancellationToken);
    }
    public Task<TEntity?> Query(TEntity value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return SendAndReceiveJson(MinimalApiMethodCatalog.Query, value, options, query, cancellationToken);
    }
    public Task<TEntity?> Get(TEntity value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return SendAndReceiveJson(MinimalApiMethodCatalog.Get, value, options, query, cancellationToken);
    }
    
    public Task<TEntity?> Create(JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return ReceiveJson(MinimalApiMethodCatalog.Create, options, query, cancellationToken);
    }
    public Task<TEntity?> CreateOrUpdate(JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return ReceiveJson(MinimalApiMethodCatalog.CreateOrUpdate, options, query, cancellationToken);
    }
    public Task<TEntity?> Delete(JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return ReceiveJson(MinimalApiMethodCatalog.Delete, options, query, cancellationToken);
    }
    public Task<TEntity?> Fetch(JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return ReceiveJson(MinimalApiMethodCatalog.Fetch, options, query, cancellationToken);
    }
    public Task<TEntity?> Query(JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return ReceiveJson(MinimalApiMethodCatalog.Query, options, query, cancellationToken);
    }
    public Task<TEntity?> Get(JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return ReceiveJson(MinimalApiMethodCatalog.Get, options, query, cancellationToken);
    }
}

public class MinimalHttpClient<TRequest, TResponse>(
    HttpClient http,
    IMinimalApiRouteProvider routeProvider)
{
    private readonly Type[] _types = [typeof(TRequest), typeof(TResponse)];

    public HttpRequestMessage CreateHttpRequestMessage(string type, string? query = null)
        => new (HttpMethod.Post, routeProvider.GetRoute(type, _types, query));
    protected virtual Task BeforeSend(HttpRequestMessage requestMessage) => Task.CompletedTask;

    public async Task<TResponse?> Send(string type, TRequest value,
        JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        var requestMessage = CreateHttpRequestMessage(type, query);
        var content = JsonContent.Create(value, mediaType: null, options);
        requestMessage.Content = content;
        await BeforeSend(requestMessage);
        var httpResponse = await http.SendAsync(requestMessage, cancellationToken);
        return await httpResponse.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
    }

    public Task<TResponse?> Create(TRequest value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return Send(MinimalApiMethodCatalog.Create, value, options, query, cancellationToken);
    }
    public Task<TResponse?> CreateOrUpdate(TRequest value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return Send(MinimalApiMethodCatalog.CreateOrUpdate, value, options, query, cancellationToken);
    }
    public Task<TResponse?> Update(TRequest value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return Send(MinimalApiMethodCatalog.Update, value, options, query, cancellationToken);
    }
    public Task<TResponse?> Delete(TRequest value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return Send(MinimalApiMethodCatalog.Delete, value, options, query, cancellationToken);
    }
    public Task<TResponse?> Fetch(TRequest value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return Send(MinimalApiMethodCatalog.Fetch, value, options, query, cancellationToken);
    }
    public Task<TResponse?> Query(TRequest value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return Send(MinimalApiMethodCatalog.Query, value, options, query, cancellationToken);
    }
    public Task<TResponse?> Get(TRequest value, JsonSerializerOptions? options = null, string? query = null, CancellationToken cancellationToken = default)
    {
        return Send(MinimalApiMethodCatalog.Get, value, options, query, cancellationToken);
    }
}
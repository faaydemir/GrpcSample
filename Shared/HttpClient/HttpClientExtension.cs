using System.Net;
using System.Net.Http.Json;

public static class HttpClientExtension
{
    public static async Task<TResponse> Get<TResponse>(this HttpClient httpClient, string url)
    {
        var response = await httpClient.GetAsync(url);
        return await HandleResponse<TResponse>(response);
    }
    public static async Task<TResponse> Put<TResponse, TPayload>(this HttpClient httpClient, string url, TPayload payload)
    {
        var response = await httpClient.PutAsJsonAsync(url, payload);
        return await HandleResponse<TResponse>(response);
    }
    public static async Task Put<TPayload>(this HttpClient httpClient, string url, TPayload payload)
    {
        var response = await httpClient.PutAsJsonAsync(url, payload);
        await EnsureStatusCodeOk(response);
    }
    public static async Task<TResponse> Post<TResponse, TPayload>(this HttpClient httpClient, string url, TPayload payload)
    {
        var response = await httpClient.PostAsJsonAsync(url, payload);
        return await HandleResponse<TResponse>(response);
    }
    public static async Task Post<TPayload>(this HttpClient httpClient, string url, TPayload payload)
    {
        var response = await httpClient.PostAsJsonAsync(url, payload);
        await EnsureStatusCodeOk(response);
    }

    private static async Task EnsureStatusCodeOk(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var errorResponse = response.Content.Headers.ContentLength > 0
                    ? await response.Content.ReadFromJsonAsync<ErrorResponse>()
                    : ErrorResponse.Default;

            throw new ApiException(errorResponse.Message, errorResponse.StatusCode);
        }
    }
    private static async Task<TResponse> HandleResponse<TResponse>(HttpResponseMessage response)
    {
        await EnsureStatusCodeOk(response);

        return response.Content.Headers.ContentLength > 0
                ? await response.Content.ReadFromJsonAsync<TResponse>()
                : default(TResponse);
    }
}

public class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public ApiException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}
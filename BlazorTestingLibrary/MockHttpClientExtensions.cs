using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using RichardSzalay.MockHttp;

namespace BlazorTestingLibrary;

public static class MockHttpClientExtensions
{
    public static MockHttpMessageHandler AddMockHttpClient(this TestServiceProvider services, string baseUrl = "http://localhost")
    {
        var mockHttpHandler = new MockHttpMessageHandler();
        var httpClient = mockHttpHandler.ToHttpClient();
        httpClient.BaseAddress = new Uri(baseUrl);
        services.AddSingleton(httpClient);
        return mockHttpHandler;
    }

    public static MockedRequest RespondJson<T>(this MockedRequest request, T content)
    {
        request.Respond(req =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(content));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        });
        return request;
    }

    public static MockedRequest RespondJson<T>(this MockedRequest request, Func<T> contentProvider)
    {
        request.Respond(req =>
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(JsonSerializer.Serialize(contentProvider()));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        });
        return request;
    }
}
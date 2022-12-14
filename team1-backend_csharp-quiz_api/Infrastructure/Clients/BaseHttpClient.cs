using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace team1_backend_csharp_quiz_api.Infrastructure.Clients;

public abstract class BaseHttpClient
{
    internal readonly HttpClient _client;

    protected BaseHttpClient(HttpClient httpClient)
    {
        _client = httpClient;
    }

    protected async Task<T> GetAsync<T>(string route)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, GetEndPointUrl(route));
        return await SendRequestAsync<T>(request);
    }

    private async Task<T> SendRequestAsync<T>(HttpRequestMessage request)
    {
        using (var response = await _client.SendAsync(request))
        {
            var jsonResponse = await response.Content.ReadAsStreamAsync();
            var responseModel = await JsonSerializer.DeserializeAsync<T>(jsonResponse);

            return responseModel;
        }
    }

    protected Uri GetEndPointUrl(string route)
    {
        return new Uri($"{_client.BaseAddress?.ToString().TrimEnd('/')}/{route}");
    }
}

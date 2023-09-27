using MyBasketStats.ClientApp.Helpers;
using MyBasketStats.ClientApp.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace MyBasketStats.Client;

public class MyBasketStatsAPIClient
{
    private HttpClient _client;
    public MyBasketStatsAPIClient(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://localhost:7091");
        _client.Timeout = new TimeSpan(0, 0, 30);
    }

    public async Task<string> GetResourcesAsync(string route)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            route);
        request.Headers.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return content;
    }

    public async Task<string> GetResourceAsync(string route, int id)
    {
        var request = new HttpRequestMessage(
                       HttpMethod.Get,
                                  $"{route}/{id}");
        request.Headers.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return content;
    }

    public async Task<string> DeleteResourceAsync(string route, int id)
    {
        var request = new HttpRequestMessage(
                       HttpMethod.Delete,
                                  $"{route}/{id}");
        request.Headers.Accept.Add(
                       new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return content;
    }


    public async Task<string> CreateResourceAsync(string route, string serializedResourceToCreate)
    {        
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "api/teams");
        request.Headers.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        request.Content = new StringContent(serializedResourceToCreate);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        return content;
    }

}

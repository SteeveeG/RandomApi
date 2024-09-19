using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using RandomApi.Models;

namespace RandomApi.ApiCalls;

public class ApiCalls
{
    public static async Task<string> AlexWohlbruckCatFacts()
    {
       var result = await GetIn<AlexWohlbruckCatFactsModel>("/facts/random", "https://cat-fact.herokuapp.com");
       return result.text;
    }
    public static async Task<string> RandomDuk()
    {
       var result = await GetIn<RandomDukModel>("/random", "https://random-d.uk/api");
       return result.url;
    }

    private static async Task<T> GetIn<T>(string requestUri , string baseUrl)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.GetAsync(requestUri);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }

        return default;
    }
}
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using RandomApi.Models;
using RandomApi.Models.AnimeQuote;

namespace RandomApi.ApiCalls;

public class ApiCalls
{
    public static async Task<string> CatFacts()
    {
       var result = await GetIn<CatFactsModel>("/facts/random", "https://cat-fact.herokuapp.com");
       return result.text;
    }  
    public static async Task<AnimeQuote> AnimeQuote()
    {
       var result = await GetIn<AnimeQuote>("quotes/random", "https://animechan.io/api/v1/");
       return result;
    }  
    public static async Task<Jikan> AnimeRecommendation()
    {
       var result = await GetIn<Jikan>("random/anime", "https://api.jikan.moe/v4/");
       return result;
    }
    public static async Task<string> RandomDuk()
    {
       var result = await GetIn<RandomDukModel>("random", "https://random-d.uk/api/");
       return result.url;
    }  
    public static async Task<string> RandomFox()
    {
       var result = await GetIn<RandomFox>("floof", "https://randomfox.ca/");
       return result.image;
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
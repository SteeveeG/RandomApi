using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using RandomApi.Models;
using RandomApi.Models.AnimeQuote;
using RandomApi.Models.MetObjects;

namespace RandomApi.ApiCalls;

public class ApiCalls
{
   private static Random random = new Random();
   private static ObjectIds ObjectsIds = new();

   public static async void Init()
   {
      ObjectsIds = await GetIn<ObjectIds>("search?q=*&hasImages=true", "https://collectionapi.metmuseum.org/public/collection/v1/");
   }
   
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
    public static async Task<results> NekoBest()
    {
       var result = await GetIn<results>("neko", "https://nekos.best/api/v2/");
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
    public static async Task<MetObject> RandomArtWork()
    {
       var result = await GetIn<MetObject>($"objects/{ObjectsIds.objectIds[random.Next(0,ObjectsIds.objectIds.Count)]}",
          "https://collectionapi.metmuseum.org/public/collection/v1/");
       return result;
    }   
    public static async Task<string> RandomNoiseColor()
    {
       var result = await GetIn<Noise>("noise.php?r=${r}&g=${g}&b=${b}&tiles=${tiles}&tileSize=${tileSize}&borderWidth=${borderWidth}&mode=${mode}&json", 
          "https://php-noise.com/");
       return result.uri;
    }    
    public static async Task<VolumeResponse> GoogleBooks()
    {
       var result = await GetIn<VolumeResponse>("volumes?q=*&maxResults=40", 
          "https://www.googleapis.com/books/v1/");
       return result;
    }  
    public static async Task<string> WaifuPics()
    {
       string[] actions = {
          "waifu", "neko", "shinobu", "megumin",
          "bully", "cuddle", "cry", "hug",
          "awoo", "kiss", "lick", "pat",
          "smug", "bonk", "yeet", "blush",
          "smile", "wave", "highfive", "handhold",
          "nom", "bite", "glomp", "slap",
          "kill", "kick", "happy", "wink",
          "poke", "dance", "cringe"
       };
       var result = await GetIn<Url>($"sfw/{actions[random.Next(0,actions.Length)]}", "https://api.waifu.pics/");
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

 
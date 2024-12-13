using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using RandomApi.Models;
using RandomApi.Models.AnimeQuote;
using RandomApi.Models.MetObjects;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace RandomApi.ApiCalls;

public class ApiCalls
{
    private static Random random = new();
    private static ObjectIds ObjectsIds = new();
    private static Authors Authors = new();
    private static List<string> FreeGamesIds = new();
    private static string[] phrases = {
    "You're as useful as a screen door on a submarine.",
    "Your brain runs slower than a 90s dial-up connection.",
    "You're about as sharp as a marble.",
    "You're like a cloud. When you disappear, it’s a beautiful day.",
    "You bring everyone so much joy… when you leave the room.",
    "You're like a software bug: annoying and hard to fix.",
    "If stupidity were an Olympic sport, you’d win gold.",
    "You're proof that even bad ideas deserve a chance.",
    "You have something on your chin… no, the third one down.",
    "Your logic is so broken, it could be a TikTok trend.",
    "You're like a Wi-Fi signal in the woods – non-existent.",
    "You're not stupid; you just have bad luck thinking.",
    "You're like a cactus in a balloon shop – always out of place.",
    "You're so awkward, even mirrors look away.",
    "If ignorance is bliss, you must be ecstatic.",
    "You bring nothing to the table… not even the table.",
    "You're the human version of a typo.",
    "You're like an expired coupon – completely useless.",
    "If brains were dynamite, you couldn’t blow your nose.",
    "You're so basic, even vanilla calls you plain.",
    "You're like a floppy disk – outdated and irrelevant.",
    "You're proof that anyone can exist without a purpose.",
    "You're so fake, even Barbie is jealous.",
    "You're like a Windows update – nobody asked for you.",
    "You’re the reason they put directions on shampoo bottles.",
    "You're like a lighthouse in the desert – pointless.",
    "Your IQ test results came back negative.",
    "You're like a broken pencil – pointless.",
    "You're like a math problem nobody wants to solve.",
    "You're like a browser tab that won’t close – irritating and unnecessary.",
    "You're the human equivalent of a typo.",
    "You're as bright as a black hole.",
    "You're like a pop-up ad – annoying and hard to ignore.",
    "You’re so slow, even Google timed out on you.",
    "You're like a broken clock – right twice a day.",
    "You have something special… the ability to irritate everyone.",
    "You're like a parked car in a race – going nowhere.",
    "Your life is like a 404 error – not found.",
    "You're like a flat tire – holding everyone back.",
    "You're so predictable, even your shadow gets bored.",
    "You're like a bad movie – everyone regrets watching you.",
    "You're like a penguin at the beach – completely out of place.",
    "You're the Wi-Fi of people: either weak or disconnected.",
    "You're so extra, even your shadow rolls its eyes.",
    "You’re like a slow-loading webpage – frustrating and outdated.",
    "Your personality is as dull as unbuttered toast.",
    "You're the human version of low battery mode.",
    "You're like a printer: loud, slow, and always out of ink.",
    "You’re like a door without a handle – completely useless.",
    "You're the reason aliens won’t visit Earth.",
    "You're like an empty fridge – disappointing and cold.",
    "You're like a soap opera – dramatic and hard to take seriously.",
    "You're the human version of spam email.",
    "You're so lost, even GPS gave up on you.",
    "You're like a vending machine that takes the money but doesn’t deliver.",
    "You’re like a backup file – always forgotten.",
    "You're the glitch in life's software.",
    "You're like a pop quiz – nobody wants you around.",
    "You're like a lost sock – nobody misses you.",
    "You’re like a selfie stick – completely unnecessary.",
    "You're like an off-brand cereal – nobody chooses you on purpose.",
    "You're like a mosquito – tiny, irritating, and unwelcome.",
    "You're the result of a failed experiment.",
    "You're like a karaoke singer off-key – painful to listen to.",
    "You’re like a QR code that doesn’t scan.",
    "You’re like a password I forgot – frustrating and useless.",
    "You're like a group text – unnecessary and annoying.",
    "You're like a crash-test dummy – constantly getting wrecked.",
    "You're like a dead pixel – ruining the picture for everyone.",
    "You're like autocorrect – always messing things up.",
    "You're the human version of a buffering video.",
    "You’re like an umbrella in a hurricane – useless and in the way.",
    "You’re like a movie sequel nobody asked for.",
    "You’re like the ‘Skip Ad’ button that doesn’t work.",
    "You’re like a snowflake in July – irrelevant.",
    "You’re like a traffic cone – in the way and orange.",
    "You’re like a manual transmission – outdated and difficult to handle.",
    "You're like a forgotten password – impossible to deal with.",
    "You're like an elevator that only goes down – disappointing.",
    "You're like a coffee without caffeine – pointless.",
    "You’re like a printer jam – annoying and hard to fix.",
    "You’re like a bookmark in a terrible book – in the wrong place.",
    "You're like a clock with no hands – useless and confusing.",
    "You're the human version of airplane mode.",
    "You're like a frozen computer – completely unresponsive.",
    "You're like the last slice of pizza no one wants.",
    "You’re like a slow computer mouse – frustrating and lagging.",
    "You’re like a plug that doesn’t fit any outlet.",
    "You’re like an umbrella with holes – barely helpful.",
    "You’re like a cheap knockoff – obvious and disappointing.",
    "You're like a candle in the sun – out of place and pointless.",
    "You’re like a sticker that doesn’t stick – totally useless.",
    "You’re like a scratched CD – skipping through life.",
    "You’re like a bad Wi-Fi password – annoying and overcomplicated.",
    "You’re like an out-of-tune piano – unbearable to listen to.",
    "You're like a car with no gas – stuck and useless.",
    "You're like a joke without a punchline – just sad.",
    "You’re like a shadow – always following but never helping.",
    "You're like a fish on a bicycle – completely unnecessary.",
    "You're like a closed caption with typos – a mess.",
    "You’re like a dollar store battery – cheap and unreliable.",
    "You’re like a doorbell that doesn’t work – pointless.",
    "You’re like a spam call at 2 a.m. – unwanted and annoying.",
    "You’re like an app that crashes every time – unreliable.",
    "You're like a soda that’s gone flat – disappointing.",
    "You’re like a broken pencil sharpener – unable to do the basics.",
    "You’re like a car alarm that won’t stop – irritating and pointless.",
    "You’re like a shopping cart with a broken wheel – annoying and hard to handle.",
    "You’re like a bad haircut – awkward and embarrassing.",
    "You’re like a soggy sandwich – sad and unappetizing.",
    "You’re like a photocopy of a photocopy – faded and irrelevant."
};

    public async void Init()
    {
        //GetObject Ids For Further Api Call
        ObjectsIds = await GetIn<ObjectIds>("search?q=*&hasImages=true",
            "https://collectionapi.metmuseum.org/public/collection/v1/");
        Authors = await GetIn<Authors>("author", "https://poetrydb.org/");
       await LoadFreeGamesIds();
    }

    private async Task LoadFreeGamesIds()
    {
        var allgames = await GetInString("games", "https://www.freetogame.com/api/");
        do
        {
            var indexIDStart = allgames.IndexOf("{\"id\":");
            var IndesTitleStart = allgames.IndexOf("\"title\":");
            var IndexEndJsonObject = allgames.IndexOf("freetogame_profile_url");
            
            var substring = allgames.Substring(indexIDStart, IndesTitleStart);

            var indexOf = substring.IndexOf(":");

            FreeGamesIds.Add(substring.Substring(indexOf+1,substring.IndexOf(",")-indexOf-1));
            allgames = allgames.Substring(IndexEndJsonObject+22);
            if (!allgames.Contains("id"))
            {
                break;
            }

        } while (true);
    }

    public async Task<string> CatFacts()
    {
        var result = await GetIn<CatFactsModel>("/facts/random", "https://cat-fact.herokuapp.com");
        return result.text;
    }

    public async Task<AnimeQuote> AnimeQuote()
    {
        var result = await GetIn<AnimeQuote>("quotes/random", "https://animechan.io/api/v1/");
        return result;
    }

    public async Task<Jikan> AnimeRecommendation()
    {
        var result = await GetIn<Jikan>("random/anime", "https://api.jikan.moe/v4/");
        return result;
    }

    public async Task<string> RandomDuk()
    {
        var result = await GetIn<Url>("random", "https://random-d.uk/api/");
        return result.url;
    }

    public async Task<string> RandomFox()
    {
        var result = await GetIn<RandomFox>("floof", "https://randomfox.ca/");
        return result.image;
    }

    public async Task<MetObject> RandomArtWork()
    {
        var result = await GetIn<MetObject>(
            $"objects/{ObjectsIds.objectIds[random.Next(0, ObjectsIds.objectIds.Count)]}",
            "https://collectionapi.metmuseum.org/public/collection/v1/");
        return result;
    }

    public async Task<List<lines>> RandomPoem()
    {
        var index = random.Next(0, Authors.authors.Count);
        var result = await GetIn<List<lines>>(
            $"author/{Authors.authors[index]}/lines",
            "https://poetrydb.org/");

        if (result.Count > 50)
        {
            result = result[..50];
        }

        result.Add(new lines { Lines = [] });
        result[^1].Lines.Add(Authors.authors[index]);
        return result;
    }

    public async Task<string> RandomNoiseColor()
    {
        var result = await GetIn<Noise>(
            "noise.php?r=${r}&g=${g}&b=${b}&tiles=${tiles}&tileSize=${tileSize}&borderWidth=${borderWidth}&mode=${mode}&json",
            "https://php-noise.com/");
        return result.uri;
    }

    public async Task<VolumeResponse> GoogleBooks()
    {
        var result = await GetIn<VolumeResponse>("volumes?q=*&maxResults=40",
            "https://www.googleapis.com/books/v1/");
        return result;
    }

    public async Task<string> WaifuPics()
    {
        string[] actions =
        [
            "waifu", "neko", "shinobu", "megumin",
            "bully", "cuddle", "cry", "hug",
            "awoo", "kiss", "lick", "pat",
            "smug", "bonk", "yeet", "blush",
            "smile", "wave", "highfive", "handhold",
            "nom", "bite", "glomp", "slap",
            "kill", "kick", "happy", "wink",
            "poke", "dance", "cringe"
        ];
        var result = await GetIn<Url>($"sfw/{actions[random.Next(0, actions.Length)]}", "https://api.waifu.pics/");
        return result.url;
    }


    public async Task<List<Holiday>> GetHolidays()
    {
        var result = await GetIn<List<Holiday>>("NextPublicHolidaysWorldwide", "https://date.nager.at/api/v3/");
        return result;
    }

    public async Task<UrlValue> GetChuckNorrisJoke()
    {
        var result = await GetIn<UrlValue>("jokes/random", "https://api.chucknorris.io/ ");
        return result;
    }

    public async Task<CorporateBullshit> GetCorporateBullshitPhrase()
    {
        var result = await GetIn<CorporateBullshit>("", "https://corporatebs-generator.sameerkumar.website/");
        return result;
    }

    public async Task<Excuser> GetExcuse()
    {
        var result = await GetIn<List<Excuser>>("excuse/1", "https://excuser-three.vercel.app/v1/");
        return result[0];
    }

    public async Task<Text> GetUselessFact()
    {
        var result = await GetIn<Text>("api/v2/facts/random", "https://uselessfacts.jsph.pl/");
        return result;
    }

    public async Task<Message> GetUselessTechSentence()
    {
        var result = await GetIn<Message>("api/json", "https://techy-api.vercel.app/");
        return result;
    }

    public async Task<Dog> GetDogFact()
    {
        var result = await GetIn<Dog>("facts?limit=1", "https://dogapi.dog/api/v2/");
        return result;
    }

    public async Task<food> GetFoodPic()
    {
        var result = await GetIn<food>("api/", "https://foodish-api.com/");
        return result;
    }

    public async Task<Brewery> GetBreweries()
    {
        var result = await GetIn<List<Brewery>>("random", "https://api.openbrewerydb.org/v1/breweries/");
        return result[0];
    }

    public async Task<FreeGames> GetFreeGame()
    {
        if (FreeGamesIds.Count == 0)
        {
            Thread.Sleep(2500);
        }
        var result = await GetIn<FreeGames>($"game?id={FreeGamesIds[random.Next(0,FreeGamesIds.Count)]}", "https://www.freetogame.com/api/");
        return result;
        
    }
    public async Task<Joke> GetJoke()
    {
        var result = await GetIn<Joke>("api?format=json", "https://geek-jokes.sameerkumar.website/");
        return result;
        
    }
    
    public async Task<JokeResponse> GetAnotherJoke()
    {
        var result = await GetIn<JokeResponse>("Any?type=single", "https://v2.jokeapi.dev/joke/");
        return result;

    }
    public async Task<RickMortyCharacter> GetRickAndMortyCharacter()
    {
        var result = await GetIn<RickMortyCharacter>($"character/{random.Next(0,827)}", "https://rickandmortyapi.com/api/");
        return result;
    }

    public async Task<SteamStats> GetSteamStats()
    {
        var result = await GetIn<SteamStats>("about/stats", "https://www.valvesoftware.com/de/");
        return result;
    }

    public async Task<Mcu> GetNextMcuMovie()
    {
        var result = await GetIn<Mcu>("api", "https://dev.whenisthenextmcufilm.com/");
        return result;
    }


    private async Task<T> GetIn<T>(string requestUri, string baseUrl)
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
    
    private async Task<string> GetInString(string requestUri, string baseUrl)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        var response = await client.GetAsync(requestUri);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return default;
    }
    private async Task<T> GetInXml<T>(string requestUri, string baseUrl)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(baseUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml")); // Akzeptiere XML-Antworten

        var response = await client.GetAsync(requestUri);
        if (response.IsSuccessStatusCode)
        {
            var contentStream = await response.Content.ReadAsStreamAsync();
            var serializer = new XmlSerializer(typeof(T));   
            return (T)serializer.Deserialize(contentStream); 
        }

        return default;
    }
}
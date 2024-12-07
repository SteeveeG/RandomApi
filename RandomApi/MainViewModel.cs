using System.Globalization;
using RandomApi.Helpers;
using RandomApi.Models;

namespace RandomApi;

public class MainViewModel : ViewModelBase
{
    private string quote;
    private string apiWebAddress;
    private string imgLink;
    private bool isQuoteVisible;
    private bool isImgVisible;
 
    public DelegateCommand VisitApiWebCommand { get; }
    public DelegateCommand ApiCallCommand { get; }
    private ApiCalls.ApiCalls ApiCalls { get; set; }
    private static Dictionary<string, string> countries = new()
    {
        { "AD", "Andorra" },
        { "AL", "Albania" },
        { "AM", "Armenia" },
        { "AR", "Argentina" },
        { "AT", "Austria" },
        { "AU", "Australia" },
        { "AX", "Åland Islands" },
        { "BA", "Bosnia and Herzegovina" },
        { "BB", "Barbados" },
        { "BE", "Belgium" },
        { "BG", "Bulgaria" },
        { "BJ", "Benin" },
        { "BO", "Bolivia" },
        { "BR", "Brazil" },
        { "BS", "Bahamas" },
        { "BW", "Botswana" },
        { "BY", "Belarus" },
        { "BZ", "Belize" },
        { "CA", "Canada" },
        { "CH", "Switzerland" },
        { "CL", "Chile" },
        { "CN", "China" },
        { "CO", "Colombia" },
        { "CR", "Costa Rica" },
        { "CU", "Cuba" },
        { "CY", "Cyprus" },
        { "CZ", "Czechia" },
        { "DE", "Germany" },
        { "DK", "Denmark" },
        { "DO", "Dominican Republic" },
        { "EC", "Ecuador" },
        { "EE", "Estonia" },
        { "EG", "Egypt" },
        { "ES", "Spain" },
        { "FI", "Finland" },
        { "FO", "Faroe Islands" },
        { "FR", "France" },
        { "GA", "Gabon" },
        { "GB", "United Kingdom" },
        { "GD", "Grenada" },
        { "GE", "Georgia" },
        { "GG", "Guernsey" },
        { "GI", "Gibraltar" },
        { "GL", "Greenland" },
        { "GM", "Gambia" },
        { "GR", "Greece" },
        { "GT", "Guatemala" },
        { "GY", "Guyana" },
        { "HK", "Hong Kong" },
        { "HN", "Honduras" },
        { "HR", "Croatia" },
        { "HT", "Haiti" },
        { "HU", "Hungary" },
        { "ID", "Indonesia" },
        { "IE", "Ireland" },
        { "IM", "Isle of Man" },
        { "IS", "Iceland" },
        { "IT", "Italy" },
        { "JE", "Jersey" },
        { "JM", "Jamaica" },
        { "JP", "Japan" },
        { "KR", "South Korea" },
        { "KZ", "Kazakhstan" },
        { "LI", "Liechtenstein" },
        { "LS", "Lesotho" },
        { "LT", "Lithuania" },
        { "LU", "Luxembourg" },
        { "LV", "Latvia" },
        { "MA", "Morocco" },
        { "MC", "Monaco" },
        { "MD", "Moldova" },
        { "ME", "Montenegro" },
        { "MG", "Madagascar" },
        { "MK", "North Macedonia" },
        { "MN", "Mongolia" },
        { "MS", "Montserrat" },
        { "MT", "Malta" },
        { "MX", "Mexico" },
        { "MZ", "Mozambique" },
        { "NA", "Namibia" },
        { "NE", "Niger" },
        { "NG", "Nigeria" },
        { "NI", "Nicaragua" },
        { "NL", "Netherlands" },
        { "NO", "Norway" },
        { "NZ", "New Zealand" },
        { "PA", "Panama" },
        { "PE", "Peru" },
        { "PG", "Papua New Guinea" },
        { "PL", "Poland" },
        { "PR", "Puerto Rico" },
        { "PT", "Portugal" },
        { "PY", "Paraguay" },
        { "RO", "Romania" },
        { "RS", "Serbia" },
        { "RU", "Russia" },
        { "SE", "Sweden" },
        { "SG", "Singapore" },
        { "SI", "Slovenia" },
        { "SJ", "Svalbard and Jan Mayen" },
        { "SK", "Slovakia" },
        { "SM", "San Marino" },
        { "SR", "Suriname" },
        { "SV", "El Salvador" },
        { "TN", "Tunisia" },
        { "TR", "Turkey" },
        { "UA", "Ukraine" },
        { "US", "United States" },
        { "UY", "Uruguay" },
        { "VA", "Vatican City" },
        { "VE", "Venezuela" },
        { "VN", "Vietnam" },
        { "ZA", "South Africa" },
        { "ZW", "Zimbabwe" }
    };

    public MainViewModel()
    {
        ApiCalls = new ApiCalls.ApiCalls();
        ApiCallCommand = new DelegateCommand(ApiCall);
        VisitApiWebCommand = new DelegateCommand(VisitApiWeb);
        IsImgVisible = true;
        IsQuoteVisible = true;
        ApiCalls.Init();
    }

    private async void ApiCall()
    {
        var random = new Random();
        switch (0)
        {
            case 0:
                ApiCallQuotes();
                break;
            case 1: 
                ApiCallImg();
                break;
        }
      
    }

    private async void ApiCallQuotes()
    {
        var random = new Random();
        IsImgVisible = false;
         switch (/*random.Next() % 4*/ 14)
        {
            case 0:
            Quote = await ApiCalls.CatFacts();
            ApiWebAddress = "https://github.com/alexwohlbruck/cat-facts";
            break;
            case 1:
                var animeQuoteResult = await ApiCalls.AnimeQuote();
                Quote = animeQuoteResult.data.content + "\n" + animeQuoteResult.data.anime.name + " ~" + animeQuoteResult.data.character.name;
                ApiWebAddress = "https://github.com/Animechan-API/animechan";
                break;
            case 2:
                var animeRecommendationResult = await ApiCalls.AnimeRecommendation();
                var episodes = animeRecommendationResult.data.episodes < 1? "episodes": "episode";
                Quote = $"Anime Recommendation: {animeRecommendationResult.data.title} it has {animeRecommendationResult.data.episodes} {episodes} ";
                if (animeRecommendationResult.data.genres != null)
                {
                    var genreString = animeRecommendationResult.data.genres.Aggregate("", (current, genre) => current + (genre.name + ", "));
                    if (genreString.Length != 0)
                    {
                        genreString = genreString.Remove(genreString.Length - 2);
                        Quote += $"and the genres are: {genreString} ";
                    }
                }
                if (animeRecommendationResult.data.images != null)
                {
                    IsImgVisible = true;
                    ImgLink = animeRecommendationResult.data.images.jpg.large_image_url;
                }
                if (animeRecommendationResult.data.synopsis != null)
                {
                    Quote += $"The Story is about: {animeRecommendationResult.data.synopsis}";
                }
                ApiWebAddress = "https://jikan.moe/";
                break;
            case 3:   
                //todo Null Exception Fixen
                var googleBooks = await ApiCalls.GoogleBooks(); 
                var i = random.Next(0, googleBooks.items.Count);
                Quote = $"Book Recommendation: {googleBooks.items[i].volumeInfo.title} from" +
                        $" {googleBooks.items[i].volumeInfo.authors.First()} and the description: {googleBooks.items[i].volumeInfo.description}";
                if (googleBooks.items[i].volumeInfo.imageLinks != null)
                {
                    IsImgVisible = true;
                    ImgLink = googleBooks.items[i].volumeInfo.imageLinks.thumbnail;
                }
                ApiWebAddress = "https://github.com/Animechan-API/animechan";
                break;
            case 4:
                var listPoem = await ApiCalls.RandomPoem();
                var author = listPoem[^1].Lines[0];
                listPoem.RemoveAt(listPoem.IndexOf(listPoem[^1]));
                var poem = listPoem[random.Next(0, listPoem.Count)];
                var finishedPoem = poem.Lines.Aggregate(string.Empty, (current, line) => current + (line + "\n"));
                Quote = finishedPoem.Remove(finishedPoem.Length - 1);
                ApiWebAddress = "https://github.com/thundercomb/poetrydb";
                break;
            case 5:
                var holidays = await ApiCalls.GetHolidays();
                var holiday = holidays[random.Next(0, holidays.Count)];
                Quote =
                    $"one of the upcoming holidays is : {holiday.name}" +
                    $"\noriginal name : {holiday.localName}" +
                    $"\nthis is on {holiday.date.Value:dd/M/yyyy} and is celebrated in the country: {countries[holiday.countryCode]}";
                break;
            case 6:
                var chuckNorrisJoke = await ApiCalls.GetChuckNorrisJoke();
                Quote = chuckNorrisJoke.value;
                ApiWebAddress = chuckNorrisJoke.url;
                break;
            case 7:
                var corporateBullshit = await ApiCalls.GetCorporateBullshitPhrase();
                Quote = $"Here a Dumb sentence for your next Bullshit Meeting:\n{corporateBullshit.phrase}";
                ApiWebAddress = "https://github.com/sameerkumar18/corporate-bs-generator-api";
                break;
            case 8:
                var excuser = await ApiCalls.GetExcuse();
                Quote = $"here an excuse: {excuser.excuse}";
                break;
            case 9:
                var uselessFact = await ApiCalls.GetUselessFact();
                Quote = uselessFact.text;
                ApiWebAddress = "https://uselessfacts.jsph.pl/";
                break;
            case 10:
                var uselessTechSentence = await ApiCalls.GetUselessTechSentence();
                Quote = $"Here a useless Tech Sentence: {uselessTechSentence.message}";
                ApiWebAddress = "https://uselessfacts.jsph.pl/";
                break;
            case 11:
                var dog = await ApiCalls.GetDogFact();
                Quote = dog.data[0].attributes.body;
                ApiWebAddress = "https://dogapi.dog/";
                break;
            case 12:
                var brewery = await ApiCalls.GetBreweries();
                Quote = $"Here a Brewery: {brewery.name}, its location is in {brewery.address_1}" +
                        $"in the country {brewery.country}";
                if (brewery.country != null)
                {
                    Quote += $" with the Website {brewery.website_url}";

                }
                ApiWebAddress = "https://www.openbrewerydb.org/";
                break;
            case 13: 
                var freeGame = await ApiCalls.GetFreeGame();
                Quote = $"A Free Game to Play: {freeGame.title} the genre are {freeGame.genre} you can play it" +
                        $"on the platform {freeGame.platform} from the publisher {freeGame.publisher} " +
                        $"the description of the game {freeGame.short_description}";

                if (freeGame.screenshots == null)
                {
                    if (freeGame.thumbnail != null)
                    {
                        ImgLink = freeGame.thumbnail;
                    }
                }
                else
                {
                    foreach (var screenshot in freeGame.screenshots)
                    {
                        ImgLink = screenshot.image;
                        IsImgVisible = true;
                        break;
                    }
                }

                ApiWebAddress = "https://www.freetogame.com/api-doc";
                break;
            case 14:
                var joke = await ApiCalls.GetJoke();
                Quote = joke.joke;
                ApiWebAddress = "https://github.com/sameerkumar18/geek-joke-api";
                break;
        }
         
        IsQuoteVisible = true;
    }
    private async void ApiCallImg()
    {
        var random = new Random();
        IsQuoteVisible = false;
        isImgVisible = false;
        switch (/*random.Next() % 4*/5)
        {
            case 0:
                ImgLink  = await ApiCalls.RandomDuk();
                ApiWebAddress = "https://random-d.uk/api";
                break;
            case 1:
                ImgLink = await ApiCalls.RandomFox();
                ApiWebAddress = "https://randomfox.ca/";
                break;
            case 2:
                ImgLink = await ApiCalls.WaifuPics();
                ApiWebAddress = "https://waifu.pics/";
                break;   
            case 3:
                var result = await ApiCalls.RandomArtWork();
                ImgLink = result.primaryimage;
                if (!string.IsNullOrEmpty(result.title) && !string.IsNullOrWhiteSpace(result.title))
                {
                    Quote = $"The Artwork Called : {result.title} ";
                }
                if (!string.IsNullOrEmpty(result.artistdisplayname) && !string.IsNullOrWhiteSpace(result.artistdisplayname))
                {
                    Quote += $"\nfrom the Artist : {result.artistdisplayname}";
                }
                IsQuoteVisible = true;
                ApiWebAddress = "https://metmuseum.github.io/";
                break;   
            case 4:
                ImgLink = await ApiCalls.RandomNoiseColor();
                ApiWebAddress = "https://metmuseum.github.io/";
                Quote = "A Random Noise Color";
                IsQuoteVisible = true;
                break;
            case 5:
                var foodPic = await ApiCalls.GetFoodPic();
                ImgLink = foodPic.image;
                Quote = "Yummy";
                IsQuoteVisible = true;
                break;
            
        }
        IsImgVisible = true;
    }
    
    
   
    private void VisitApiWeb()
    {
    }


    public string Quote
    {
        get => quote;
        set
        {
            if (value == quote) return;
            quote = value;
            OnPropertyChanged();
        }
    }

    public string ImgLink
    {
        get => imgLink;
        set
        {
            if (value == imgLink) return;
            imgLink = value;
            OnPropertyChanged();
        }
    }

    public string ApiWebAddress
    {
        get => apiWebAddress;
        set
        {
            if (value == apiWebAddress) return;
            apiWebAddress = value;
            OnPropertyChanged();
        }
    }
    public bool IsQuoteVisible
    {
        get => isQuoteVisible;
        set
        {
            if (value == isQuoteVisible) return;
            isQuoteVisible = value;
            OnPropertyChanged();
        }
    }
    public bool IsImgVisible
    {
        get => isImgVisible;
        set
        {
            if (value == isImgVisible) return;
            isImgVisible = value;
            OnPropertyChanged();
        }
    }
}
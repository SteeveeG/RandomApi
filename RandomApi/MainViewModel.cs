using System.Diagnostics;
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
    private bool randomCallIsClicked;

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
        ApiCallCommand = new DelegateCommand(Call);
        VisitApiWebCommand = new DelegateCommand(VisitApiWeb);
        IsImgVisible = true;
        IsQuoteVisible = true;
        RandomCallIsClicked = true;
        ApiCalls.Init();
    }

    private async void Call()
    {
        RandomCallIsClicked = false;
        await ApiCall();
        Thread.Sleep(100);
        RandomCallIsClicked = true;
    }

    private async Task ApiCall()
    {
        var random = new Random();
        IsImgVisible = false;
        IsQuoteVisible = false;
         switch (random.Next() %  28)
        {
            case 0:
            Quote = await ApiCalls.CatFacts();
            ApiWebAddress = "https://github.com/alexwohlbruck/cat-facts";
                IsQuoteVisible = true;
                break;
            case 1:
                var animeQuoteResult = await ApiCalls.AnimeQuote();
                Quote = animeQuoteResult.data.content + "\n" + animeQuoteResult.data.anime.name + " ~" + animeQuoteResult.data.character.name;
                ApiWebAddress = "https://github.com/Animechan-API/animechan";
                IsQuoteVisible = true;
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
                IsQuoteVisible = true;
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
                IsQuoteVisible = true;
                break;
            case 4:
                var listPoem = await ApiCalls.RandomPoem();
                var author = listPoem[^1].Lines[0];
                listPoem.RemoveAt(listPoem.IndexOf(listPoem[^1]));
                var poem = listPoem[random.Next(0, listPoem.Count)];
                var finishedPoem = poem.Lines.Aggregate(string.Empty, (current, line) => current + (line + "\n"));
                Quote = finishedPoem.Remove(finishedPoem.Length - 1);
                ApiWebAddress = "https://github.com/thundercomb/poetrydb";
                IsQuoteVisible = true;
                break;
            case 5:
                var holidays = await ApiCalls.GetHolidays();
                var holiday = holidays[random.Next(0, holidays.Count)];
                Quote =
                    $"one of the upcoming holidays is : {holiday.name}" +
                    $"\noriginal name : {holiday.localName}" +
                    $"\nthis is on {holiday.date.Value:dd/M/yyyy} and is celebrated in the country: {countries[holiday.countryCode]}";
                IsQuoteVisible = true;
                break;
            case 6:
                var chuckNorrisJoke = await ApiCalls.GetChuckNorrisJoke();
                Quote = chuckNorrisJoke.value;
                ApiWebAddress = chuckNorrisJoke.url;
                IsQuoteVisible = true;
                break;
            case 7:
                var corporateBullshit = await ApiCalls.GetCorporateBullshitPhrase();
                Quote = $"Here a Dumb sentence for your next Bullshit Meeting:\n{corporateBullshit.phrase}";
                ApiWebAddress = "https://github.com/sameerkumar18/corporate-bs-generator-api";
                IsQuoteVisible = true;
                break;
            case 8:
                var excuser = await ApiCalls.GetExcuse();
                Quote = $"here an excuse: {excuser.excuse}";
                IsQuoteVisible = true;
                break;
            case 9:
                var uselessFact = await ApiCalls.GetUselessFact();
                Quote = uselessFact.text;
                ApiWebAddress = "https://uselessfacts.jsph.pl/";
                IsQuoteVisible = true;
                break;
            case 10:
                var uselessTechSentence = await ApiCalls.GetUselessTechSentence();
                Quote = $"Here a useless Tech Sentence: {uselessTechSentence.message}";
                ApiWebAddress = "https://uselessfacts.jsph.pl/";
                IsQuoteVisible = true;
                break;
            case 11:
                var dog = await ApiCalls.GetDogFact();
                Quote = dog.data[0].attributes.body;
                ApiWebAddress = "https://dogapi.dog/";
                IsQuoteVisible = true;
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
                IsQuoteVisible = true;
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
                IsQuoteVisible = true;
                ApiWebAddress = "https://www.freetogame.com/api-doc";
                break;
            case 14:
                var joke = await ApiCalls.GetJoke();
                Quote = joke.joke;
                IsQuoteVisible = true;
                ApiWebAddress = "https://github.com/sameerkumar18/geek-joke-api";
                break;
            case 15:
                var anotherjoke = await ApiCalls.GetAnotherJoke();
                Quote = anotherjoke.joke;
                IsQuoteVisible = true;
                ApiWebAddress = "https://github.com/sameerkumar18/geek-joke-api";
                break;
            case 16:
                var rickMortyCharacter = await ApiCalls.GetRickAndMortyCharacter();
                Quote = "Here is a Character from The Series Rick and Morty: " +
                        $"the Name is {rickMortyCharacter.name}, currently {rickMortyCharacter.status}" +
                        $" and has the gender {rickMortyCharacter.gender}";
                ImgLink = rickMortyCharacter.image;
                IsImgVisible = true;
                ApiWebAddress = "https://www.rickmorty.com/";
                IsQuoteVisible = true;
                break;
            case 17:
                var nexMcuMovie = await ApiCalls.GetNextMcuMovie();
                Quote = $"in {nexMcuMovie.days_until} days the new Mcu Movie {nexMcuMovie.title} will be released its on the {nexMcuMovie.release_date}";
                ImgLink = nexMcuMovie.poster_url;
                ApiWebAddress = "https://github.com/DiljotSG/MCU-Countdown";
                IsImgVisible = true;
                IsQuoteVisible = true;
                break;
            case 18:
                var covidStats = await ApiCalls.GetCovidStats();
                Quote =$"Here are the latest COVID-19 statistics: The data is based on {covidStats.latest_date}. " +
                       $"There were {covidStats.change_cases} changes compared to the previous update. " +
                       $"There was {covidStats.change_fatalities} fatality change compared to the previous update. " +
                       $"The total cases were {covidStats.total_cases}, and the total fatal cases were also {covidStats.total_fatalities}.";
                ApiWebAddress = "https://api.covid19tracker.ca/docs/1.0/overview";
                IsQuoteVisible = true;
                break;

            case 19:
                var randomGenre = await ApiCalls.GetRandomGenre();
                Quote = $"A new Genre For your Story if you need one: {randomGenre}";
                ApiWebAddress = "https://binaryjazz.us/genrenator-api/";
                IsQuoteVisible = true;
                break;
            case 20:
                var spaceFlightNews = await ApiCalls.GetSpaceFlightNews();
                Quote = $"{spaceFlightNews.title}\n{spaceFlightNews.summary}";
                ImgLink = spaceFlightNews.image_url;
                IsImgVisible = true;
                IsQuoteVisible = true;
                ApiWebAddress = "https://spaceflightnewsapi.net/";
                break;
            case 21:
                ImgLink  = await ApiCalls.RandomDuk();    
                IsImgVisible = true;
                ApiWebAddress = "https://random-d.uk/api";
                break;
            case 22:
                ImgLink = await ApiCalls.RandomFox();              
                IsImgVisible = true;
                ApiWebAddress = "https://randomfox.ca/";
                break;
            case 23:
                ImgLink = await ApiCalls.WaifuPics();
                IsImgVisible = true;
                ApiWebAddress = "https://waifu.pics/";
                break;   
            case 24:
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
                IsImgVisible = true;
                break;   
            case 25:
                ImgLink = await ApiCalls.RandomNoiseColor();
                ApiWebAddress = "https://metmuseum.github.io/";
                Quote = "A Random Noise Color";
                IsQuoteVisible = true; 
                IsImgVisible = true;
                break;
            case 26:
                var foodPic = await ApiCalls.GetFoodPic();
                ImgLink = foodPic.image;
                Quote = "Yummy";
                IsQuoteVisible = true;
                IsImgVisible = true;
                break;
            case 27:
                var insult = await ApiCalls.GetRandomInsult();
                Quote = insult.insult;
                ApiWebAddress = "https://evilinsult.com/api/";
                IsQuoteVisible = true;
                break;
            case 28:
                var advice = await ApiCalls.GetAdvice();
                Quote = advice.slip.advice;
                ApiWebAddress = "https://api.adviceslip.com/";
                IsQuoteVisible = true;
                break;
        }

    }
   
    private void VisitApiWeb()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = ApiWebAddress,
            UseShellExecute = true 
        });
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

    public bool RandomCallIsClicked
    {
        get => randomCallIsClicked;
        set
        {
            if (value == randomCallIsClicked) return;
            randomCallIsClicked = value;
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
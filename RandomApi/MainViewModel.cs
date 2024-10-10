using RandomApi.Helpers;
 
namespace RandomApi;

public class MainViewModel : ViewModelBase
{
    private string quote;
    private string apiWebAddress;
    private string imgLink;
    private bool isQuoteVisible;
    private bool isImgVisible;
    public DelegateCommand CopyTextImgCommand { get; }
    public DelegateCommand ChangeThemeCommand { get; }
    public DelegateCommand VisitApiWebCommand { get; }
    public DelegateCommand ApiCallCommand { get; }

    public MainViewModel()
    {
        ApiCallCommand = new DelegateCommand(ApiCall);
        CopyTextImgCommand = new DelegateCommand(CopyTextImg);
        ChangeThemeCommand = new DelegateCommand(ChangeTheme);
        VisitApiWebCommand = new DelegateCommand(VisitApiWeb);
        IsImgVisible = true;
        IsQuoteVisible = true;
        ApiCalls.ApiCalls.Init();
    }

    private async void ApiCall()
    {
        var random = new Random();
        switch (random.Next() % 2)
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
 
        switch (3)
        {
            case 0:
            Quote = await ApiCalls.ApiCalls.CatFacts();
            ApiWebAddress = "https://github.com/alexwohlbruck/cat-facts";
            break;
            case 1:
                var animeQuoteResult = await ApiCalls.ApiCalls.AnimeQuote();
                Quote = animeQuoteResult.data.content + "\n" + animeQuoteResult.data.anime.name + "~ " + animeQuoteResult.data.character.name;
                ApiWebAddress = "https://github.com/Animechan-API/animechan";
                break;
            case 2:
                var animeRecommendationResult = await ApiCalls.ApiCalls.AnimeRecommendation();
                Quote = $"Anime Recommendation: {animeRecommendationResult.data.title} it has {animeRecommendationResult.data.episodes} episodes ";
                if (animeRecommendationResult.data.genres != null)
                {
                    var genreString = animeRecommendationResult.data.genres.Aggregate("", (current, genre) => current + (genre.name + ", "));
                    if (genreString.Length != 0)
                    {
                        genreString = genreString.Remove(genreString.Length - 2);
                        Quote += $"and the genres are {genreString}";
                    }
                }
                if (animeRecommendationResult.data.images != null)
                {
                    ImgLink = animeRecommendationResult.data.images.jpg.large_image_url;
                }
                ApiWebAddress = "https://jikan.moe/";
                break;
            case 3:   
                var googleBooks = await ApiCalls.ApiCalls.GoogleBooks(); 
                var i = random.Next(0, googleBooks.items.Count);
                Quote = $"Book Recommendation: {googleBooks.items[i].volumeInfo.title} from" +
                        $" {googleBooks.items[i].volumeInfo.authors.First()} and the description: {googleBooks.items[i].volumeInfo.description}";
                if (googleBooks.items[i].volumeInfo.imageLinks != null)
                {
                    ImgLink = googleBooks.items[i].volumeInfo.imageLinks.thumbnail;
                }
                ApiWebAddress = "https://github.com/Animechan-API/animechan";
                break;
            
        }
    }
    private async void ApiCallImg()
    {
        var random = new Random();
        switch (5)
        {
            case 0:
                ImgLink = await ApiCalls.ApiCalls.RandomDuk();
                ApiWebAddress = "https://random-d.uk/api";
                break;
            case 1:
                ImgLink = await ApiCalls.ApiCalls.RandomFox();
                ApiWebAddress = "https://randomfox.ca/";
                break;
            case 2:
                var results = await ApiCalls.ApiCalls.NekoBest();
                Quote = $"Artist: {results.artist_name}";
                ImgLink = results.url;
                ApiWebAddress = "https://docs.nekos.best/";
                break;
            case 3:
                ImgLink = await ApiCalls.ApiCalls.WaifuPics();
                ApiWebAddress = "https://waifu.pics/";
                break;   
            case 4:
                var result = await ApiCalls.ApiCalls.RandomArtWork();
                ImgLink = result.primaryimage;
                ApiWebAddress = "https://metmuseum.github.io/";
                break;   
            case 5:
                ImgLink = await ApiCalls.ApiCalls.RandomNoiseColor();
                ApiWebAddress = "https://metmuseum.github.io/";
                break;
            
        }
    }
    
    
   
    private void VisitApiWeb()
    {
    }

    private void ChangeTheme()
    {
    }

    private void CopyTextImg()
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
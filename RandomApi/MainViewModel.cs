using RandomApi.Helpers;
 
namespace RandomApi;

public class MainViewModel : ViewModelBase
{
    private string quote;
    private string apiWebAddress;
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
        switch (random.Next())
        {
            case 0:
            Quote = await ApiCalls.ApiCalls.AlexWohlbruckCatFacts();
            ApiWebAddress = "https://github.com/alexwohlbruck/cat-facts";
            break;
            
            
        }
    }
    private void ApiCallImg()
    {
       
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
}
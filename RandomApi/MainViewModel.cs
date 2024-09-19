using RandomApi.Helpers;

namespace RandomApi;

public class MainViewModel : ViewModelBase
{
    private string quote;

    public MainViewModel()
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

    public object CopyTextImgCommand { get; }
}
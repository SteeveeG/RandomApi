using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomApi;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private Random random = new Random();
    private string currentStyleName = "Button1";

    private void Move(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void ChangeStyle(object sender, RoutedEventArgs e)
    {
        string newButtonStyleName,  headerStyleName, quoteStyleName, backgroundStyleName;
        do
        {
            var num = random.Next(1, 11);
            newButtonStyleName = $"Button{num}";
            headerStyleName = $"Label{num}";
            quoteStyleName = $"TextBlock{num}";
            backgroundStyleName = $"Background{num}";
        } while (currentStyleName == newButtonStyleName);

        currentStyleName = newButtonStyleName;
        btn1.Style = (Style)FindResource(newButtonStyleName);
        btn2.Style = (Style)FindResource(newButtonStyleName);
        btn3.Style = (Style)FindResource(newButtonStyleName);
        btn4.Style = (Style)FindResource(newButtonStyleName);
        Quote.Style = (Style)FindResource(quoteStyleName);
        Header.Style = (Style)FindResource(headerStyleName);
        Background.Style = (Style)FindResource(backgroundStyleName);

    }
}
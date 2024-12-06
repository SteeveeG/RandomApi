namespace RandomApi.Models;

public class FreeGames
{
    public string title { get; set; }
    public string thumbnail { get; set; }
    public string short_description { get; set; }
    public string genre { get; set; }
    public string platform { get; set; }
    public string publisher { get; set; }
    public List<Screenshot>? screenshots { get; set; }
}

public class Screenshot
{
    public string image { get; set; }
}
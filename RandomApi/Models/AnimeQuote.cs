namespace RandomApi.Models.AnimeQuote;

public class AnimeQuote
{
    public data data { get; set; }
}
public class data
{
    public string content { get; set; }
    public anime anime { get; set; }
    public character character { get; set; }
}

public class character
{
    public string name { get; set; }
}

public class anime
{
    public string name { get; set; }
}
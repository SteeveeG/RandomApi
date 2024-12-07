namespace RandomApi.Models;

public class Joke
{
    public string joke { get; set; }
}

public class JokeResponse
{
    public string type { get; set; }
    public string joke { get; set; }
}

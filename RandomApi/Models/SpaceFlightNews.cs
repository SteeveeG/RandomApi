namespace RandomApi.Models;

public class SpaceFlightNews
{
    public int count { get; set; }
    public string next { get; set; }
    public string previous { get; set; }
    public List<Result> results { get; set; }
}

public class Result
{
    public int id { get; set; }
    public string title { get; set; }
    public string url { get; set; }
    public string image_url { get; set; }
    public string news_site { get; set; }
    public string summary { get; set; }
    public DateTime published_at { get; set; }
    public DateTime updated_at { get; set; }
    public bool featured { get; set; }
    public List<Launch> launches { get; set; }
    public List<Event> events { get; set; }
}

public class Launch
{
    public string launch_id { get; set; }
    public string provider { get; set; }
}

public class Event
{
    public int event_id { get; set; }
    public string provider { get; set; }
}
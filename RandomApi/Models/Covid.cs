namespace RandomApi.Models;

public class Covid
{
    public List<Data> data { get; set; }
}

public class Data
{
    public string latest_date { get; set; }
    public string change_cases { get; set; }
    public string change_fatalities { get; set; }
    public string total_cases { get; set; }
    public string total_fatalities { get; set; }
}
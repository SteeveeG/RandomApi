namespace RandomApi.Models;

public class CatFactsModel
{
    public status status { get; set; }
    public string _id { get; set; }
    public string user { get; set; }
    public string text { get; set; }
    public string type { get; set; }
    public bool deleted { get; set; }
    public string createdAt { get; set; }
    public string updatedAt { get; set; }
    public int __v { get; set; }
}

public class status
{
    public bool? verified { get; set; }
    public int sentCount { get; set; }
}
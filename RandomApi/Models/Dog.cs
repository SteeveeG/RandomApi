namespace RandomApi.Models;

public class Dog
{
    public List<data> data { get; set; }
}

public class data
{
    public attributes attributes { get; set; }
}

public class attributes
{
    public string body { get; set; }
}
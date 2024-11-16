namespace RandomApi.Models.MetObjects;

public class MetObject
{
    public string primaryimage { get; set; }
    public string title { get; set; }
    public string artistdisplayname { get; set; }
}

public class ObjectIds
{
    public List<int> objectIds { get; set; } = new();
}
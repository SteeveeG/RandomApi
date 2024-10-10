namespace RandomApi.Models;

public class VolumeResponse
{
    public string kind { get; set; }
    public int totalItems { get; set; }
    public List<Volume> items { get; set; }
}

public class Volume
{
    public VolumeInfo volumeInfo { get; set; }
}

public class VolumeInfo
{
    public string title { get; set; }
    public string subtitle { get; set; }
    public List<string> authors { get; set; }
    public string publisher { get; set; }
    public string publishedDate { get; set; }
    public string description { get; set; }
    public int pageCount { get; set; }
    public string maturityRating { get; set; }
    public ImageLinks? imageLinks { get; set; }
    public string language { get; set; }
    public string previewLink { get; set; }
}

public class ImageLinks
{
    public string smallThumbnail { get; set; }
    public string thumbnail { get; set; }
}
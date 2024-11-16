public class Jikan
{
    public Data data { get; set; }
}


public class Image
{
    public string? image_url { get; set; }
    public string? small_image_url { get; set; }
    public string? large_image_url { get; set; }
}

public class Images
{
    public Image? jpg { get; set; }
    public Image? webp { get; set; }
}

public class Genre
{
    public string? name { get; set; }
}

public class Data
{

    public Images? images { get; set; }
    public string? title { get; set; }
    public int? episodes { get; set; }
    public string? synopsis { get; set; }
    public List<Genre>? genres { get; set; }

}



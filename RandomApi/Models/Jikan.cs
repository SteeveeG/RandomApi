public class Jikan
{
    public Data data { get; set; }
}

public class Title
{
    public string? type { get; set; }
    public string? title { get; set; }
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

public class Trailer
{
    public string? youtube_id { get; set; }
    public string? url { get; set; }
    public string? embed_url { get; set; }
}

public class Aired
{
    public string? from { get; set; }
    public string? to { get; set; }
    public Prop? prop { get; set; }
}

public class Prop
{
    public int? day { get; set; }
    public int? month { get; set; }
    public int? year { get; set; }
    public string? propString { get; set; }
}

public class Broadcast
{
    public string? day { get; set; }
    public string? time { get; set; }
    public string? timezone { get; set; }
    public string? broadcastString { get; set; }
}

public class Producer
{
    public int? mal_id { get; set; }
    public string? type { get; set; }
    public string? name { get; set; }
    public string? url { get; set; }
}

public class Licensor
{
    public int? mal_id { get; set; }
    public string? type { get; set; }
    public string? name { get; set; }
    public string? url { get; set; }
}

public class Studio
{
    public int? mal_id { get; set; }
    public string? type { get; set; }
    public string? name { get; set; }
    public string? url { get; set; }
}

public class Genre
{
    public int? mal_id { get; set; }
    public string? type { get; set; }
    public string? name { get; set; }
    public string? url { get; set; }
}

public class Data
{
    public int? mal_id { get; set; }
    public string? url { get; set; }
    public Images? images { get; set; }
    public Trailer? trailer { get; set; }
    public bool? approved { get; set; }
    public List<Title>? titles { get; set; }
    public string? title { get; set; }
    public string? title_english { get; set; }
    public string? title_japanese { get; set; }
    public List<string>? title_synonyms { get; set; }
    public string? type { get; set; }
    public string? source { get; set; }
    public int? episodes { get; set; }
    public string? status { get; set; }
    public bool? airing { get; set; }
    public Aired? aired { get; set; }
    public string? duration { get; set; }
    public string? rating { get; set; }
    public double? score { get; set; }
    public int? scored_by { get; set; }
    public int? rank { get; set; }
    public int? popularity { get; set; }
    public int? members { get; set; }
    public int? favorites { get; set; }
    public string? synopsis { get; set; }
    public string? background { get; set; }
    public string? season { get; set; }
    public int? year { get; set; }
    public Broadcast? broadcast { get; set; }
    public List<Producer>? producers { get; set; }
    public List<Licensor>? licensors { get; set; }
    public List<Studio>? studios { get; set; }
    public List<Genre>? genres { get; set; }
    public List<Genre>? explicit_genres { get; set; }
    public List<Genre>? themes { get; set; }
    public List<Genre>? demographics { get; set; }
}

public class Published
{
    public string? from { get; set; }
    public string? to { get; set; }
    public Prop? prop { get; set; }
}
public class Author
{
    public int? mal_id { get; set; }
    public string? type { get; set; }
    public string? name { get; set; }
    public string? url { get; set; }
}

public class Serialization
{
    public int? mal_id { get; set; }
    public string? type { get; set; }
    public string? name { get; set; }
    public string? url { get; set; }
}

 
public class MangaData
{
    public int? mal_id { get; set; }
    public string? url { get; set; }
    public Images? images { get; set; }
    public bool? approved { get; set; }
    public List<Title>? titles { get; set; }
    public string? title { get; set; }
    public string? title_english { get; set; }
    public string? title_japanese { get; set; }
    public string? type { get; set; }
    public int? chapters { get; set; }
    public int? volumes { get; set; }
    public string? status { get; set; }
    public bool? publishing { get; set; }
    public Published? published { get; set; }
    public int? score { get; set; }
    public int? scored_by { get; set; }
    public int? rank { get; set; }
    public int? popularity { get; set; }
    public int? members { get; set; }
    public int? favorites { get; set; }
    public string? synopsis { get; set; }
    public string? background { get; set; }
    public List<Author>? authors { get; set; }
    public List<Serialization>? serializations { get; set; }
    public List<Genre>? genres { get; set; }
    public List<Genre>? explicit_genres { get; set; }
    public List<Genre>? themes { get; set; }
    public List<Genre>? demographics { get; set; }
}
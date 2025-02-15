using Newtonsoft.Json;

public partial class Meldungen
{
    [JsonProperty("meldungId")]
    public int MeldungId { get; set; }

    [JsonProperty("timestamp")]
    public int Timestamp { get; set; }

    [JsonProperty("lat")]
    public required string Lat { get; set; }

    [JsonProperty("lon")]
    public required string Lon { get; set; }

    [JsonProperty("place")]
    public required string Place { get; set; }

    [JsonProperty("category")]
    public required string Category { get; set; }

    [JsonProperty("auspraegung")]
    public required string Auspraegung { get; set; }

    [JsonProperty("zusatzAttribute")]
    public List<string>? ZusatzAttribute { get; set; }

    [JsonProperty("likeCount")]
    public int LikeCount { get; set; }

    [JsonProperty("imageUrl", NullValueHandling = NullValueHandling.Ignore)]
    public Uri? ImageUrl { get; set; }

    [JsonProperty("imageThumbUrl", NullValueHandling = NullValueHandling.Ignore)]
    public Uri? ImageThumbUrl { get; set; }

    [JsonProperty("imageMediumUrl", NullValueHandling = NullValueHandling.Ignore)]
    public Uri? ImageMediumUrl { get; set; }

    [JsonProperty("blurHash", NullValueHandling = NullValueHandling.Ignore)]
    public string? BlurHash { get; set; }

    [JsonProperty("imageThumbWidth", NullValueHandling = NullValueHandling.Ignore)]
    public int? ImageThumbWidth { get; set; }

    [JsonProperty("imageThumbHeight", NullValueHandling = NullValueHandling.Ignore)]
    public int? ImageThumbHeight { get; set; }
}
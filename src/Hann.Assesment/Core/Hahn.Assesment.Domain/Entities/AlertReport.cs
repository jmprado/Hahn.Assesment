namespace Hahn.Assesment.Domain.Entities;

public class AlertReport
{
    public int Id { get; set; }
    public int Timestamp { get; set; }
    public string Lat { get; set; } = "";
    public string Lon { get; set; } = "";
    public string Place { get; set; } = "";
    public string Category { get; set; } = "";
    public string Condition { get; set; } = "";
    public List<string>? ExtraAttribute { get; set; } = new List<string>();
    public int LikeCount { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageThumbUrl { get; set; }
    public string? ImageMediumUrl { get; set; }
    public string? BlurHash { get; set; }
    public int? ImageThumbWidth { get; set; }
    public int? ImageThumbHeight { get; set; }

    public Guid AlertId { get; set; }
    public virtual AlertEntity? Alerts { get; set; }
}

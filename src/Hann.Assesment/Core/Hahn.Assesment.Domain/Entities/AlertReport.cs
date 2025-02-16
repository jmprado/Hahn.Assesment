using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.Assesment.Domain.Entities;

public class AlertReport
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public int ReportId { get; set; }
    public DateTime AlertDate { get; set; }
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

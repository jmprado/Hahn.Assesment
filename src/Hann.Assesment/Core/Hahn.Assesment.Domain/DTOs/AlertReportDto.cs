namespace Hahn.Assesment.Domain.DTOs;

public class AlertReportDto
{
    public Guid Id { get; set; }
    public int ReportId { get; set; }
    public string ReportDate { get; set; } = string.Empty;
    public string Lat { get; set; } = string.Empty;
    public string Lon { get; set; } = string.Empty;
    public string? Place { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Condition { get; set; } = string.Empty;
    public List<string>? ExtraAttribute { get; set; }
    public int LikeCount { get; set; }
    public string? ImageUrl { get; set; } = string.Empty;
    public string? ImageThumbUrl { get; set; } = string.Empty;
    public string? ImageMediumUrl { get; set; } = string.Empty;
    public string? BlurHash { get; set; } = string.Empty;
    public int? ImageThumbWidth { get; set; }
    public int? ImageThumbHeight { get; set; }
    public Guid AlertId { get; set; }
}
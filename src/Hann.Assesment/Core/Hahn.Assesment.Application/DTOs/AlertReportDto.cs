namespace Hahn.Assesment.Application.DTOs;

public class AlertReportDto
{
    public Guid Id { get; set; }
    public int ReportId { get; set; }
    public required string ReportDate { get; set; }
    public required string Lat { get; set; }
    public required string Lon { get; set; }
    public string? Place { get; set; }
    public required string Category { get; set; }
    public required string Condition { get; set; }
    public List<string>? ExtraAttribute { get; set; }
    public int LikeCount { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageThumbUrl { get; set; }
    public string? ImageMediumUrl { get; set; }
    public string? BlurHash { get; set; }
    public int? ImageThumbWidth { get; set; }
    public int? ImageThumbHeight { get; set; }
    public Guid AlertId { get; set; }
}


using Hahn.Assesment.Domain;

namespace Hahn.Assesment.Application.DTOs;

public class SeverityReportDto
{
    public int ReportId { get; set; }
    public int Timestamp { get; set; }
    public string Lat { get; set; }
    public string Lon { get; set; }
    public string Place { get; set; }
    public string Category { get; set; }
    public string Condition { get; set; }
    public List<string>? ExtraAttribute { get; set; }
    public int LikeCount { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageThumbUrl { get; set; }
    public string? ImageMediumUrl { get; set; }
    public string? BlurHash { get; set; }
    public int? ImageThumbWidth { get; set; }
    public int? ImageThumbHeight { get; set; }
    public Guid SeverityAlertId { get; set; }

    public SeverityReportDto(SeverityReport report)
    {
        ReportId = report.ReportId;
        Timestamp = report.Timestamp;
        Lat = report.Lat;
        Lon = report.Lon;
        Place = report.Place;
        Category = report.Category;
        Condition = report.Condition;
        ExtraAttribute = report.ExtraAttribute;
        LikeCount = report.LikeCount;
        ImageUrl = report.ImageUrl;
        ImageThumbUrl = report.ImageThumbUrl;
        ImageMediumUrl = report.ImageMediumUrl;
        BlurHash = report.BlurHash;
        ImageThumbWidth = report.ImageThumbWidth;
        ImageThumbHeight = report.ImageThumbHeight;
    }
}


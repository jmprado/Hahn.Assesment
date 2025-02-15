namespace Hahn.Assesment.Application.DTOs.SeverityDtos;

public class SeverityAlertDto
{
    public Guid Id { get; set; } = new Guid();
    public DateTime UpdatedAt { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public int WindowsSizeHours { get; set; }

    public virtual IEnumerable<SeverityReportDto>? SeverityReports { get; set; }
    public virtual IEnumerable<SeverityCategoryDto>? SeverityCategories { get; set; }
}
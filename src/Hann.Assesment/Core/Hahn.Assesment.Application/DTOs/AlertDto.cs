namespace Hahn.Assesment.Application.DTOs.SeverityDtos;

public class AlertDto
{
    public Guid Id { get; set; } = new Guid();
    public DateTime UpdatedAt { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public int WindowsSizeHours { get; set; }

    public virtual IEnumerable<AlertReportDto>? SeverityReports { get; set; }
    public virtual IEnumerable<AlertCategoryDto>? SeverityCategories { get; set; }
}
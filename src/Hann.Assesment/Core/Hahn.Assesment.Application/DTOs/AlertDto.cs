namespace Hahn.Assesment.Application.DTOs.SeverityDtos;

public class AlertDto
{
    public Guid Id { get; set; } = new Guid();
    public DateTime UpdatedAt { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public short WindowsSizeHours { get; set; }

    public virtual IEnumerable<AlertReportDto>? SeverityReports { get; set; }
    public virtual IEnumerable<AlertCategoryDto>? SeverityCategories { get; set; }
}
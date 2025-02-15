using Hahn.Assesment.Application.DTOs;

public class SeverityAlertDto
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public int WindowsSizeHours { get; set; }
    public IEnumerable<SeverityReportDto> SeverityReports { get; set; } = new List<SeverityReportDto>();
}
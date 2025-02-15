namespace Hahn.Assesment.Domain.Entities;

public record SeverityAlert
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public int WindowsSizeHours { get; set; }

    public virtual IEnumerable<SeverityReport> SeverityReports { get; set; } = new List<SeverityReport>();
}

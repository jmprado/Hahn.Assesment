namespace Hahn.Assesment.Domain.Entities;

public class SeverityAlert
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public int WindowsSizeHours { get; set; }

    public virtual IEnumerable<SeverityReport>? SeverityReports { get; set; }
}

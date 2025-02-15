namespace Hahn.Assesment.Domain.Entities;

public class Alerts
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public int WindowsSizeHours { get; set; }

    public virtual IEnumerable<AlertReport>? SeverityReport { get; set; }
    public virtual IEnumerable<AlertCategory>? SeverityCategories { get; set; }
}

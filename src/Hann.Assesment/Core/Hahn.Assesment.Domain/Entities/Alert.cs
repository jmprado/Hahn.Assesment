namespace Hahn.Assesment.Domain.Entities;

public class Alert
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Start { get; set; }
    public int End { get; set; }
    public int WindowsSizeHours { get; set; }

    public virtual IEnumerable<AlertReport>? AlertReports { get; set; }
    public virtual IEnumerable<AlertCategory>? AlertCategories { get; set; }
}

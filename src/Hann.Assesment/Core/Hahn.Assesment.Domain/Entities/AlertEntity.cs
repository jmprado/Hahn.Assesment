namespace Hahn.Assesment.Domain.Entities;

public class AlertEntity
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public short WindowsSizeHours { get; set; }

    public virtual ICollection<AlertReport>? AlertReports { get; set; }
    public virtual ICollection<AlertCategory>? AlertCategories { get; set; }
}

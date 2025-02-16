using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.Assesment.Domain.Entities;

public class AlertEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public short WindowsSizeHours { get; set; }

    public virtual IEnumerable<AlertReport>? AlertReports { get; set; }
    public virtual IEnumerable<AlertCategory>? AlertCategories { get; set; }
}

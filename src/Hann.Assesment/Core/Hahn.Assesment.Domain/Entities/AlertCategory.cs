namespace Hahn.Assesment.Domain.Entities;

public class AlertCategory
{
    public Guid Id { get; set; }
    public string Category { get; set; } = "";
    public string Condition { get; set; } = "";

    public Guid SeverityAlertId { get; set; }

    public virtual Alerts? SeverityAlert { get; set; }
}

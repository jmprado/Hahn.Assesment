namespace Hahn.Assesment.Domain.Entities;

public class SeverityCategory
{
    public Guid Id { get; set; }
    public string Category { get; set; } = "";
    public string Condition { get; set; } = "";

    public Guid SeverityAlertId { get; set; }

    public virtual SeverityAlert? SeverityAlert { get; set; }
}

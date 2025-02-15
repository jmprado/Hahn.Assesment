namespace Hahn.Assesment.Domain.Entities;

public record SeverityCategory
{
    public string Category { get; set; } = "";
    public string Condition { get; set; } = "";

    public Guid SeverityAlertId { get; set; }

    public virtual SeverityAlert? SeverityAlert { get; set; }
}

namespace Hahn.Assesment.Domain.Entities;

public class AlertCategory
{
    public Guid Id { get; set; }
    public string Category { get; set; } = "";
    public string Condition { get; set; } = "";

    public Guid AlertId { get; set; }

    public virtual Alert? Alerts { get; set; }
}

namespace Hahn.Assesment.Domain.Models.Entities;

public class CategoryEntity
{
    public Guid Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Condition { get; set; } = string.Empty;

    public Guid AlertId { get; set; }

    public virtual AlertEntity? Alerts { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Hahn.Assesment.Domain.Entities;

public class AlertCategory
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Category { get; set; } = "";
    public string Condition { get; set; } = "";

    public Guid AlertId { get; set; }

    public virtual AlertEntity? Alerts { get; set; }
}

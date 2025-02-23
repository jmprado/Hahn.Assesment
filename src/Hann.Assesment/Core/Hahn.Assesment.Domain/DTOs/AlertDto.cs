namespace Hahn.Assesment.Domain.DTOs;

public class AlertDto
{
    public Guid Id { get; set; }
    public string UpdatedAt { get; set; } = string.Empty;
    public string Start { get; set; } = string.Empty;
    public string End { get; set; } = string.Empty;
    public short WindowsSizeHours { get; set; }
}

namespace Hahn.Assesment.Application.DTOs.SeverityDtos;

public class AlertDto
{
    public Guid Id { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public short WindowsSizeHours { get; set; }
}
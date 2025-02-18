namespace Hahn.Assesment.Application.DTOs.SeverityDtos;

public class AlertDto
{
    public Guid Id { get; set; }
    public required string UpdatedAt { get; set; }
    public required string Start { get; set; }
    public required string End { get; set; }
    public short WindowsSizeHours { get; set; }
}
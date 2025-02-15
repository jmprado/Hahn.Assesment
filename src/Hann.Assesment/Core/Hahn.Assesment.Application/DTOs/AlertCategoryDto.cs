using Hahn.Assesment.Application.DTOs.SeverityDtos;

namespace Hahn.Assesment.Application.DTOs;

public class AlertCategoryDto
{
    public string Category { get; set; } = "";
    public string Condition { get; set; } = "";
    public Guid SeverityAlertId { get; set; }
    public AlertDto? SeverityAlert { get; set; }
}

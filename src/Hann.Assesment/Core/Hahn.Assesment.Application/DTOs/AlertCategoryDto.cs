namespace Hahn.Assesment.Application.DTOs;

public class AlertCategoryDto
{
    public string Category { get; set; } = "";
    public string Condition { get; set; } = "";
    public Guid AlertId { get; set; }
}

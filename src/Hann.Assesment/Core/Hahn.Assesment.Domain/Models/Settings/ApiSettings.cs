namespace Hahn.Assesment.Domain.Models.Settings;

public class ApiSettings
{
    public required string AlertEndpointUrl { get; set; }
    public required string CorsAllowedOrigins { get; set; }
}

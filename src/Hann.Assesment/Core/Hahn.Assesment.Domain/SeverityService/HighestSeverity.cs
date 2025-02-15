using Newtonsoft.Json;

namespace Hahn.Assesment.Domain.SeverityService;

public class HighestSeverity
{
    [JsonProperty("category")]
    public required string Category { get; set; }

    [JsonProperty("auspraegung")]
    public required string Auspraegung { get; set; }
}

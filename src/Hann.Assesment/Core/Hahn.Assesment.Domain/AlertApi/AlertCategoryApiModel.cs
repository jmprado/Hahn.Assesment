using Newtonsoft.Json;

namespace Hahn.Assesment.Domain.AlertApi;

public class AlertCategoryApiModel
{
    [JsonProperty("category")]
    public required string Category { get; set; }

    [JsonProperty("auspraegung")]
    public required string Auspraegung { get; set; }
}

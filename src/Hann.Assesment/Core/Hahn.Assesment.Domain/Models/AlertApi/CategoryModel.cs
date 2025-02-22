using Newtonsoft.Json;

namespace Hahn.Assesment.Domain.Models.AlertApi;

public class CategoryModel
{
    [JsonProperty("category")]
    public required string Category { get; set; }

    [JsonProperty("auspraegung")]
    public required string Auspraegung { get; set; }
}

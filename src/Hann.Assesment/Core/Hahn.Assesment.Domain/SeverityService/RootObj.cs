using Newtonsoft.Json;

namespace Hahn.Assesment.Domain.SeverityService;

public class RootObj
{
    [JsonProperty("highestSeverities")]
    public required List<HighestSeverity> HighestSeverities { get; set; }

    [JsonProperty("start")]
    public int Start { get; set; }

    [JsonProperty("end")]
    public int End { get; set; }

    [JsonProperty("windowsSizeHours")]
    public int WindowsSizeHours { get; set; }

    [JsonProperty("meldungen")]
    public List<Meldungen>? Meldungen { get; set; }
}

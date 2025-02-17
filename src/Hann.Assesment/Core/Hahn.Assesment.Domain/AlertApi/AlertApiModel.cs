using Newtonsoft.Json;

namespace Hahn.Assesment.Domain.AlertApi;

public class AlertApiModel
{
    [JsonProperty("highestSeverities")]
    public required List<AlertCategoryApiModel> AlertCategories { get; set; }

    [JsonProperty("start")]
    public long Start { get; set; }

    [JsonProperty("end")]
    public long End { get; set; }

    [JsonProperty("windowsSizeHours")]
    public int WindowsSizeHours { get; set; }

    [JsonProperty("meldungen")]
    public List<AlertReportApiModel>? AlertReports { get; set; }
}

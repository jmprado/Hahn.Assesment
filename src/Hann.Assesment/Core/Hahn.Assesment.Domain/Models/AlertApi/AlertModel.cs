using Newtonsoft.Json;

namespace Hahn.Assesment.Domain.Models.AlertApi;

public class AlertModel
{
    [JsonProperty("highestSeverities")]
    public required List<CategoryModel> AlertCategories { get; set; }

    [JsonProperty("start")]
    public long Start { get; set; }

    [JsonProperty("end")]
    public long End { get; set; }

    [JsonProperty("windowsSizeHours")]
    public int WindowsSizeHours { get; set; }

    [JsonProperty("meldungen")]
    public List<ReportModel>? AlertReports { get; set; }
}

using Hahn.Assesment.Application.DTOs.SeverityDtos;
using Hahn.Assesment.Application.Interfaces;
using Hahn.Assesment.Domain.Services.Interfaces;

namespace Hahn.Assesment.Application.Services;

public class SeverityReportAppService : ISeverityReportAppService
{
    private readonly ISeverityReportService _severityReportService;

    public SeverityReportAppService(ISeverityReportService severityReportService)
    {
        _severityReportService = severityReportService;
    }

    public async Task<IEnumerable<SeverityReportDto>> GetReportAsync()
    {
        var report = await _severityReportService.GetReportAsync();
        return report.Select(r => new SeverityReportDto(r)).ToList();
    }
}

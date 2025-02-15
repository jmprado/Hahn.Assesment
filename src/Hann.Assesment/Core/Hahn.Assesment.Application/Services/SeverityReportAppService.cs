using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Application.Interfaces;
using Hahn.Assesment.Infrastructure.Persistence.Repositories;
using Hahn.Assesment.Persistence.Services.Interfaces;

namespace Hahn.Assesment.Application.Services;

public class SeverityReportAppService : ISeverityReportAppService
{
    private readonly ISeverityApiService _severityReportApiService;
    private readonly ISeverityReportRepository _severityReportRepository;

    public SeverityReportAppService(ISeverityApiService severityReportApiService, ISeverityReportRepository severityReportRepository)
    {
        _severityReportApiService = severityReportApiService;
        _severityReportRepository = severityReportRepository;
    }

    public Task<IEnumerable<SeverityReportDto>> GetReportAsync()
    {
        throw new NotImplementedException();
    }
}

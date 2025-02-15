using Hahn.Assesment.Application.DTOs;

namespace Hahn.Assesment.Application.Interfaces;

public interface ISeverityReportAppService
{
    Task<IEnumerable<SeverityReportDto>> GetReportAsync();
}

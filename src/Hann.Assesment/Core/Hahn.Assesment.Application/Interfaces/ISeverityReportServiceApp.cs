using Hahn.Assesment.Application.DTOs.SeverityDtos;

namespace Hahn.Assesment.Application.Interfaces;

public interface ISeverityReportAppService
{
    Task<IEnumerable<SeverityReportDto>> GetReportAsync();
}

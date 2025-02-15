using Hahn.Assesment.Application.DTOs;

namespace Hahn.Assesment.Application.Interfaces;

public interface ISeverityReportAppService
{
    Task<IEnumerable<AlertReportDto>> GetReportAsync();
    Task SaveAlert();
}

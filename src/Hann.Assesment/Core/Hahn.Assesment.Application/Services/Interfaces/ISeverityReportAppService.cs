using Hahn.Assesment.Application.DTOs.SeverityDtos;

namespace Hahn.Assesment.Domain.Services.Interfaces;

public interface ISeverityReportAppService
{
    Task<IEnumerable<SeverityAlertDto>> GetReportAsync();
    Task LoadAlertDataAsync();
}
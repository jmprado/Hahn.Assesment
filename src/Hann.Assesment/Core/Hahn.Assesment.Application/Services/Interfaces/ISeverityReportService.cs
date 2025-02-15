using Hahn.Assesment.Application.DTOs.SeverityDtos;

namespace Hahn.Assesment.Domain.Services.Interfaces;

public interface ISeverityReportService
{
    Task<IEnumerable<SeverityAlertDto>> GetReportAsync();
    Task LoadAlertDataAsync();
}
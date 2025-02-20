using Hahn.Assesment.Application.DTOs;
using Hahn.Assesment.Application.DTOs.SeverityDtos;

namespace Hahn.Assesment.Application.Services
{
    public interface IAlertAppService
    {
        Task<AlertDto> GetCurrentAlertAsync();
        Task<AlertDto> GetAlertByIdAsync(Guid guid);
        Task<IEnumerable<AlertDto>> GetAlertsAsync();
        Task<IEnumerable<string>> GetCategoriesAsync(Guid guid);
        Task<IEnumerable<AlertReportDto>> GetReportsAsync(Guid guid);
    }
}

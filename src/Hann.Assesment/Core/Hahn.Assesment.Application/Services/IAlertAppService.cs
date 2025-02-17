using Hahn.Assesment.Application.DTOs;

namespace Hahn.Assesment.Application.Services
{
    public interface IAlertAppService
    {
        Task<AlertDto> GetCurrentAlertAsync();
        Task<IEnumerable<string>> GetCategoriesAsync(Guid guid);
        Task<IEnumerable<AlertReportDto>> GetReportsAsync(Guid guid);
    }
}
using Hahn.Assesment.Domain.DTOs;
using Hahn.Assesment.Domain.Models.AlertApi;

namespace Hahn.Assesment.Application.Services
{
    public interface IAlertService
    {
        Task<AlertDto?> GetAlertByIdAsync(Guid guid);
        Task<AlertDto?> GetCurrentAlertAsync();
        Task<IEnumerable<AlertDto>> GetAlertsAsync();
        Task<IEnumerable<string>> GetCategoriesAsync(Guid alertId);
        Task<IEnumerable<AlertReportDto>> GetReportsAsync(Guid alertId);
        Task<AlertModel?> LoadApiDataAsync();

        Task<Guid> AddAlertAsync(AlertModel alertModel);
        Task AddCategoriesAsync(Guid alertId, IEnumerable<CategoryModel> categories);
        Task AddReportAsync(Guid alertId, ReportModel report);
    }
}
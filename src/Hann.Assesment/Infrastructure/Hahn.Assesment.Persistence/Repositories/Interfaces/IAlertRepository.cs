using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Persistence.Repositories.Interfaces
{
    public interface IAlertRepository
    {
        Task<AlertEntity> GetAlertAsync();
        Task<AlertReport> GetReportByCategoryAsync(string category);
        Task SaveAlertAsync(AlertEntity alert);
        Task SaveAlertReport(AlertReport alertReport);
    }
}
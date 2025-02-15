using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public interface IAlertRepository
    {
        Task<Alert> GetAlertAsync();
        Task<AlertReport> GetReportByCategoryAsync(string category);
        Task SaveReportAsync(Alert alert);
    }
}
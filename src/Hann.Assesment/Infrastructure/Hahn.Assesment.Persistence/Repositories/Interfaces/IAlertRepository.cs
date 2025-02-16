using Hahn.Assesment.Domain.AlertApi;
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Persistence.Repositories.Interfaces
{
    public interface IAlertRepository
    {
        Task<AlertEntity> GetAlertAsync();
        Task<AlertReport> GetReportByCategoryAsync(string category);
        Task SaveAlertAsync(AlertApiModel alertApiModel);
    }
}
using Hahn.Assesment.Domain.AlertApi;
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Persistence.Repositories.AlertRepository
{
    public interface IAlertRepository
    {
        Task<AlertEntity?> GetCurrentAlertAsync();
        Task<IEnumerable<AlertEntity>> GetAlertsAsync(DateTime dateStart);
        Task<IEnumerable<AlertEntity>> GetAlertsAsync(DateTime dateStart, DateTime dateEnd);
        Task<Guid> AddAlertAsync(AlertApiModel alertApiModel);
    }
}
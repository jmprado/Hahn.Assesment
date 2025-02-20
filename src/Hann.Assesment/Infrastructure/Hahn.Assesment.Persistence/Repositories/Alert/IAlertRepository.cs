using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Persistence.Repositories.AlertRepository
{
    public interface IAlertRepository
    {
        Task<AlertEntity?> GetCurrentAlertAsync();
        Task<AlertEntity?> GetAlertByIdAsync(Guid id);
        Task<IEnumerable<AlertEntity>> GetAlertsAsync();
    }
}
using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public interface IAlertRepository
    {
        Task<IEnumerable<Alerts>> GetReportAsync();
        Task SaveReport(Alerts severityReport);
    }
}
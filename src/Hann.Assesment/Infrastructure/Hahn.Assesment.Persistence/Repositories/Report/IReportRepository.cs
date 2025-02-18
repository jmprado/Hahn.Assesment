using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Persistence.Repositories.Report
{
    public interface IReportRepository
    {
        Task<IEnumerable<AlertReport>> GetAlertReportsAsync(Guid alertId);
        Task AddReportAsync(AlertReport report);
    }
}
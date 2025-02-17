using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Persistence.Repositories.Report
{
    public interface IReportRepository
    {
        Task<IEnumerable<AlertReport>> GetAlertReportsAsync(Guid alertId, int pageSize = 20, int page = 0);
        Task AddReportAsync(AlertReport report);
    }
}
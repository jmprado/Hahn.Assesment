using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public interface ISeverityReportRepository
    {
        Task<IEnumerable<SeverityAlert>> GetReportAsync();
        Task SaveReport(SeverityAlert severityReport);
    }
}
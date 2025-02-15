using Hahn.Assesment.Domain;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public interface ISeverityReportRepository
    {
        Task<IEnumerable<SeverityReport>> GetReportAsync();
        Task SaveReport(int id);
    }
}
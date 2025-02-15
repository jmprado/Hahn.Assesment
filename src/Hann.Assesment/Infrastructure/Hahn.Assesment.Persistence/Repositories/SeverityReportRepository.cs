using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public class SeverityReportRepository : ISeverityReportRepository
    {
        public async Task<IEnumerable<SeverityAlert>> GetReportAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveReport(SeverityAlert severityAlert)
        {
            throw new NotImplementedException();
        }
    }
}

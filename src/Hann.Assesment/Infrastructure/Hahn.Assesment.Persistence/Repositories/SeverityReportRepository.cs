using Hahn.Assesment.Domain;
using Hahn.Assesment.Domain.Services.Interfaces;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public class SeverityReportRepository : ISeverityReportService, ISeverityReportRepository
    {
        public async Task<IEnumerable<SeverityReport>> GetReportAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveReport(int id)
        {
            throw new NotImplementedException();
        }
    }
}

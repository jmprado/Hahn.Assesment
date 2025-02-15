using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        public async Task<IEnumerable<Alerts>> GetReportAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveReport(Alerts severityAlert)
        {
            throw new NotImplementedException();
        }
    }
}

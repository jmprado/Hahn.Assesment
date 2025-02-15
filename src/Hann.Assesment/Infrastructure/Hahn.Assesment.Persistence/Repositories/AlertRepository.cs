using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        public async Task<IEnumerable<Alert>> GetReportAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveReportAsync(Alert alert)
        {
            throw new NotImplementedException();
        }

        public Task<Alert> GetAlertAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AlertReport> GetReportByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }
    }
}

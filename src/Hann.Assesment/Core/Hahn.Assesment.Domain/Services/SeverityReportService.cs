using Hahn.Assesment.Domain.Services.Interfaces;

namespace Hahn.Assesment.Domain.Services
{
    public class SeverityReportService : ISeverityReportService
    {
        private readonly List<SeverityReport> _reports = new();

        public async Task<IEnumerable<SeverityReport>> GetReportAsync()
        {
            return await Task.FromResult(_reports);
        }
    }
}

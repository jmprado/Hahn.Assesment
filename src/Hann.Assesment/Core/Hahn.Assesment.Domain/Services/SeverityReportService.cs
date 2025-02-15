using Hahn.Assesment.Domain.Services.Interfaces;

namespace Hahn.Assesment.Domain.Services
{
    public class SeverityReportService : ISeverityReportService
    {

        private readonly ISeverityApiService _severityApiService;

        public async Task<IEnumerable<SeverityReport>> GetReportAsync()
        {
            return await Task.FromResult(_reports);
        }

        public Task FetchSeverityDataAsync(SeverityReport severityReport)
        {
            throw new NotImplementedException();
        }
    }
}

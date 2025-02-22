using Hahn.Assesment.Domain.Models.Entities;

namespace Hahn.Assesment.Persistence.Repositories.Report
{
    public interface IReportRepository
    {
        Task<IEnumerable<ReportEntity>> GetAlertReportsAsync(Guid alertId, int pageSize = 20, int page = 0);
        Task AddReportAsync(ReportEntity report);
    }
}
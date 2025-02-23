using Hahn.Assesment.Domain.Models.Entities;

namespace Hahn.Assesment.Persistence.Repositories.Report
{
    public interface IReportRepository
    {
        Task<IEnumerable<ReportEntity>> GetAlertReportsAsync(Guid alertId);
        Task AddReportAsync(ReportEntity report);
    }
}
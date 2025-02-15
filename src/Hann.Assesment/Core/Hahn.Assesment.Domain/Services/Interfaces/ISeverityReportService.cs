namespace Hahn.Assesment.Domain.Services.Interfaces
{
    public interface ISeverityReportService
    {
        Task<IEnumerable<SeverityReport>> GetReportAsync();
    }
}
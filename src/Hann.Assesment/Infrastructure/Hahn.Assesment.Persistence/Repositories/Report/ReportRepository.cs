using Hahn.Assesment.Domain.Models.Entities;
using Hahn.Assesment.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Assesment.Persistence.Repositories.Report
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReportAsync(ReportEntity report)
        {
            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReportEntity>> GetAlertReportsAsync(Guid alertId, int pageSize = 20, int page = 0)
        {
            return await _context.Reports
                .OrderBy(r => r.ReportDate)
                .Where(r => r.AlertId == alertId)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}

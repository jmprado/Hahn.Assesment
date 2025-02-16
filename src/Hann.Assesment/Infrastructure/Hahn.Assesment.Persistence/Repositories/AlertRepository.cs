using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly AppDbContext _context;

        public AlertRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AlertEntity?> GetReportAsync()
        {
            return await _context.Alerts.Include(a => a.AlertCategories).Include(a => a.AlertReports).FirstOrDefaultAsync();
        }

        public async Task SaveAlertAsync(AlertEntity alert)
        {
            if (alert == null)
            {
                throw new ArgumentNullException(nameof(alert));
            }

            // Clear Alert the table before inserting new data
            await _context.Alerts.ExecuteDeleteAsync();
            await _context.SaveChangesAsync();

            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            // Set the FK AlertId for AlertCategories
            alert.AlertCategories?.All((a) => { a.AlertId = alert.Id; return true; });
            if (alert.AlertCategories != null)
            {
                foreach (var category in alert.AlertCategories)
                    _context.AlertCategories.Add(category);

                await _context.SaveChangesAsync();
                // await _context.AlertCategories.AddRangeAsync(alert.AlertCategories.ToArray());
            }

            // Set the FK AlertId for AlertReports
            alert.AlertReports?.All((a) => { a.AlertId = alert.Id; return true; });
            if (alert.AlertReports != null)
            {
                foreach (var report in alert.AlertReports)
                    _context.AlertReports.Add(report);

                await _context.SaveChangesAsync();
                //await _context.AlertReports.AddRangeAsync(alert.AlertReports.ToArray());
            }
        }

        public Task<AlertEntity> GetAlertAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AlertReport> GetReportByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAlertReport(AlertReport alertReport)
        {
            _context.AlertReports.Add(alertReport);
            await _context.SaveChangesAsync();
        }
    }
}

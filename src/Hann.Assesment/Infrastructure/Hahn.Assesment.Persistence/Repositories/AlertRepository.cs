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

            using var transaction = await _context.Database.BeginTransactionAsync();
            _context.Alerts.Add(alert);

            // Set the FK AlertId for AlertCategories
            alert.AlertCategories?.All((a) => { a.AlertId = alert.Id; return true; });

            if (alert.AlertCategories != null)
            {
                _context.AlertCategories.AddRange(alert.AlertCategories);
            }

            // Set the FK AlertId for AlertReports
            alert.AlertReports?.All((a) => { a.AlertId = alert.Id; return true; });

            if (alert.AlertReports != null)
            {
                _context.AlertyReports.AddRange(alert.AlertReports);
            }

            _context.SaveChanges();

            transaction.Commit();
        }

        public Task<AlertEntity> GetAlertAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AlertReport> GetReportByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }
    }
}

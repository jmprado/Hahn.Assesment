using AutoMapper;
using EFCore.BulkExtensions;
using Hahn.Assesment.Domain.AlertApi;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Persistence.Repositories.Interfaces;
using Hangfire;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Assesment.Infrastructure.Persistence.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AlertRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AlertEntity?> GetReportAsync()
        {
            return await _context.Alerts.Include(a => a.AlertCategories).Include(a => a.AlertReports).FirstOrDefaultAsync();
        }

        public async Task SaveAlertAsync(AlertApiModel alertApíModel)
        {
            if (alertApíModel == null)
                throw new ArgumentNullException(nameof(alertApíModel));

            using var transaction = await _context.Database.BeginTransactionAsync();

            var alert = _mapper.Map<AlertEntity>(alertApíModel);
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            // Null check for AlertCategories
            if (alertApíModel.AlertCategories == null)
                throw new ArgumentNullException(nameof(alertApíModel.AlertCategories));

            var alertCategories = _mapper.Map<List<AlertCategory>>(alertApíModel.AlertCategories);
            // Set the FK AlertId for AlertReports
            foreach (var category in alertCategories)
                category.AlertId = alert.Id;
            await _context.BulkInsertAsync(alertCategories!);

            await transaction.CommitAsync();

            // Null check for AlertReports
            if (alertApíModel.AlertReports == null)
                throw new ArgumentNullException(nameof(alertApíModel.AlertReports));

            var alertReports = _mapper.Map<List<AlertReport>>(alertApíModel.AlertReports);
            // Set the FK AlertId for AlertReports
            // Demonstration of hangfire atomic job
            foreach (var report in alertReports)
            {
                report.AlertId = alert.Id;
                BackgroundJob.Enqueue(() => SaveAlertReport(report));
            }
        }

        public async Task SaveAlertReport(AlertReport alertReport)
        {
            _context.AlertReports.Add(alertReport);
            await _context.SaveChangesAsync();
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

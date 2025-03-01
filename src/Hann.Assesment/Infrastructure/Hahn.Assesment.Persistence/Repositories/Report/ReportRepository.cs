﻿using Hahn.Assesment.Domain.Models.Entities;
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

        public async Task<IEnumerable<ReportEntity>> GetAlertReportsAsync(Guid alertId)
        {
            return await _context.Reports
                .OrderBy(r => r.ReportDate)
                .Where(r => r.AlertId == alertId)
                .ToListAsync();
        }
    }
}

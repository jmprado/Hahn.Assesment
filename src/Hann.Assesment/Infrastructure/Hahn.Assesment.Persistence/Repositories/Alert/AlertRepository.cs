using AutoMapper;
using Hahn.Assesment.Domain.AlertApi;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Assesment.Persistence.Repositories.AlertRepository
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

        public async Task<Guid> AddAlertAsync(AlertApiModel alertApíModel)
        {
            if (alertApíModel == null)
                throw new ArgumentNullException(nameof(alertApíModel));

            var alert = _mapper.Map<AlertEntity>(alertApíModel);
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            return alert.Id;
        }

        public async Task<AlertEntity?> GetCurrentAlertAsync()
        {
            return await _context.Alerts.OrderByDescending(o => o.UpdatedAt).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AlertEntity>> GetAlertsAsync(DateTime dateStart)
        {
            return await _context.Alerts
                .Where(a => a.Start >= dateStart)
                .ToListAsync();
        }

        public async Task<IEnumerable<AlertEntity>> GetAlertsAsync(DateTime dateStart, DateTime dateEnd)
        {
            return await _context.Alerts
                .Where(a => a.Start >= dateStart && a.End <= dateEnd)
                .ToListAsync();
        }
    }
}

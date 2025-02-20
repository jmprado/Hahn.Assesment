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

        /// <summary>
        /// Add alert to the database
        /// </summary>
        /// <param name="alertApíModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<Guid> AddAlertAsync(AlertApiModel alertApíModel)
        {
            if (alertApíModel == null)
                throw new ArgumentNullException(nameof(alertApíModel));

            var alert = _mapper.Map<AlertEntity>(alertApíModel);
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();

            return alert.Id;
        }

        /// <summary>
        /// Get the current alert
        /// </summary>
        /// <returns></returns>
        public async Task<AlertEntity?> GetCurrentAlertAsync()
        {
            return await _context.Alerts
                .AsNoTracking()
                .OrderByDescending(o => o.UpdatedAt)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get a list of all alerts available
        /// </summary>
        /// <param name="dateStart"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AlertEntity>> GetAlertsAsync()
        {
            return await _context.Alerts
                .AsNoTracking()
                .OrderByDescending(o => o.UpdatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Get alert by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AlertEntity?> GetAlertByIdAsync(Guid id)
        {
            return await _context.Alerts
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}

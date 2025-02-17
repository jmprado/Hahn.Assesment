using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Assesment.Persistence.Repositories.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> GetCategoriesAsync(Guid alertId)
        {
            return await _context.AlertCategories
                .Where(w => w.AlertId == alertId)
                .GroupBy(g => g.Category)
                .Select(s => s.Key)
                .OrderBy(c => c)
                .ToListAsync();
        }

        public async Task AddCategoriesAsync(IEnumerable<AlertCategory> categories)
        {
            _context.AlertCategories.AddRange(categories);
            await _context.SaveChangesAsync();
        }
    }
}

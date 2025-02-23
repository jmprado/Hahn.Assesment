using Hahn.Assesment.Domain.Models.Entities;
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
            return await _context.Categories
                .Where(w => w.AlertId == alertId)
                .GroupBy(g => g.Category)
                .Select(s => s.Key)
                .OrderBy(c => c)
                .ToListAsync();
        }

        public async Task AddCategoriesAsync(IEnumerable<CategoryEntity> categories)
        {
            _context.Categories.AddRange(categories);
            await _context.SaveChangesAsync();
        }
    }
}

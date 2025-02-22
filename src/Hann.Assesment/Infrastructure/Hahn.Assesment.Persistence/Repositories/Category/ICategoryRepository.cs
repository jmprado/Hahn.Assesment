using Hahn.Assesment.Domain.Models.Entities;

namespace Hahn.Assesment.Persistence.Repositories.Category
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<string>> GetCategoriesAsync(Guid alertId);
        Task AddCategoriesAsync(IEnumerable<CategoryEntity> categories);
    }
}
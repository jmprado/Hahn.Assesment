using Hahn.Assesment.Domain.Entities;

namespace Hahn.Assesment.Persistence.Repositories.Category
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<string>> GetCategoriesAsync(Guid alertId);
        Task AddCategoriesAsync(IEnumerable<AlertCategory> categories);
    }
}
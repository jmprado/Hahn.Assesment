using Hahn.Assesment.Domain.SeverityService;

namespace Hahn.Assesment.Persistence.Services.Interfaces
{
    public interface ISeverityApiService
    {
        public Task<AlertApiModel?> GetSeverityDataAsync();
    }
}

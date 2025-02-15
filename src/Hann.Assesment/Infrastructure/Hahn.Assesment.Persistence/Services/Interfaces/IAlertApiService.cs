using Hahn.Assesment.Domain.AlertApi;

namespace Hahn.Assesment.Persistence.Services.Interfaces
{
    public interface IAlertApiService
    {
        public Task<AlertApiModel?> GetAlertDataAsync();
    }
}

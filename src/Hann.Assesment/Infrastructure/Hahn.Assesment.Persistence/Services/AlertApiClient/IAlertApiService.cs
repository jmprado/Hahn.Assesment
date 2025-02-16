using Hahn.Assesment.Domain.AlertApi;

namespace Hahn.Assesment.Persistence.Services.AlertApi
{
    public interface IAlertApiService
    {
        public Task<AlertApiModel?> GetAlertDataAsync();
    }
}

using Hahn.Assesment.Domain.Models.AlertApi;

namespace Hahn.Assesment.Persistence.ExternalServices.AlertApi
{
    public interface IApiService
    {
        public Task<AlertModel?> GetAlertDataAsync();
    }
}

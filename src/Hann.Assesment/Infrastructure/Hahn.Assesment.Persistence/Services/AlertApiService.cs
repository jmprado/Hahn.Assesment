using Hahn.Assesment.Domain.AlertApi;
using Hahn.Assesment.Persistence.Services.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Hahn.Assesment.Persistence.Services
{
    public class AlertApiService : IAlertApiService
    {
        private readonly AlertApiSettings _alertApiSettings;

        public AlertApiService(IOptions<AlertApiSettings> options)
        {
            _alertApiSettings = options.Value;
        }

        public async Task<AlertApiModel?> GetAlertDataAsync()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(_alertApiSettings.AlertEndpointUrl);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AlertApiModel>(content);
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\r\n{ex.StackTrace}");
                throw;
            }
        }
    }
}

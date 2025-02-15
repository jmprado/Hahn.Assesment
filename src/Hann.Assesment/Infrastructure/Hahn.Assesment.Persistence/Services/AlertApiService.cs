using Hahn.Assesment.Domain.AlertApi;
using Hahn.Assesment.Persistence.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Hahn.Assesment.Persistence.Services
{
    public class AlertApiService : IAlertApiService
    {
        private readonly IConfiguration _configuration;

        public AlertApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<AlertApiModel?> GetAlertDataAsync()
        {
            try
            {
                using var client = new HttpClient();
                var url = _configuration.GetRequiredSection("SeverityApiUrl").Value;
                var response = await client.GetAsync(url);
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

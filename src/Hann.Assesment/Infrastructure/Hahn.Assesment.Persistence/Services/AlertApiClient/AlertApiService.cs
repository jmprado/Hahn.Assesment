using Hahn.Assesment.Domain.AlertApi;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace Hahn.Assesment.Persistence.Services.AlertApi
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
                var handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };

                using var client = new HttpClient(handler);
                var requestAccept = client.DefaultRequestHeaders.Accept;
                requestAccept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(new Uri(_alertApiSettings.AlertEndpointUrl));
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

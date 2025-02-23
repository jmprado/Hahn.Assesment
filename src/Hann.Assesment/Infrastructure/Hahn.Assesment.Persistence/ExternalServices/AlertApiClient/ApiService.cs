using Hahn.Assesment.Domain.Models.AlertApi;
using Hahn.Assesment.Domain.Models.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace Hahn.Assesment.Persistence.ExternalServices.AlertApi
{
    public class ApiService : IApiService
    {
        private readonly ApiSettings _alertApiSettings;

        public ApiService(IOptions<ApiSettings> options)
        {
            _alertApiSettings = options.Value;
        }

        public async Task<AlertModel?> GetAlertDataAsync()
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
                return JsonConvert.DeserializeObject<AlertModel>(content);
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

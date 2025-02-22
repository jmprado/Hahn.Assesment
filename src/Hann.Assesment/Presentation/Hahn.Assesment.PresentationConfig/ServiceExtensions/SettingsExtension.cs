using Hahn.Assesment.Hangfire;
using Hahn.Assesment.Persistence.ExternalServices.AlertApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.Assesment.Presentation.Config.ServiceExtensions;

public static class SettingsExtension
{
    public static void RegisterSettings(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<ApiSettings>(config.GetSection(nameof(ApiSettings)).Bind);
        services.Configure<JobSettings>(config.GetSection(nameof(JobSettings)).Bind);
    }
}

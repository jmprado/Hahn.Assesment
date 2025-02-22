using Hahn.Assesment.Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.Assesment.Presentation.Config.ServiceExtensions;

public static class HangfireExtension
{
    public static void AddJobSchedulingService(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IJobScheduling, JobsScheduling>();
    }
}

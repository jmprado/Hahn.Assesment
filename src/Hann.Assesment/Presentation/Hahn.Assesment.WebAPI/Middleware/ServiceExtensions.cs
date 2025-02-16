using Hahn.Assesment.Application.Services;
using Hahn.Assesment.Application.Services.Interfaces;
using Hahn.Assesment.Infrastructure;
using Hahn.Assesment.Infrastructure.Persistence.Repositories;
using Hahn.Assesment.Persistence.Repositories.Interfaces;
using Hahn.Assesment.Persistence.Services;
using Hahn.Assesment.Persistence.Services.Interfaces;

namespace Hahn.Assesment.WebAPI.Middleware;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<AlertApiSettings>(config.GetSection("AlertApiSettings"));

        services.AddDbContext<AppDbContext>();

        services.AddScoped<IAlertRepository, AlertRepository>();
        services.AddScoped<IAlertApiService, AlertApiService>();
        services.AddScoped<IAlertAppService, AlertAppService>();
    }
}

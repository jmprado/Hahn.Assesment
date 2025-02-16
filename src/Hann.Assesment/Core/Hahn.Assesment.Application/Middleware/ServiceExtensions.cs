using Hahn.Assesment.Application.Jobs;
using Hahn.Assesment.Application.Mapping;
using Hahn.Assesment.Application.Services.AlertApp;
using Hahn.Assesment.Infrastructure;
using Hahn.Assesment.Infrastructure.Persistence.Repositories;
using Hahn.Assesment.Persistence.Repositories.Interfaces;
using Hahn.Assesment.Persistence.Services.AlertApi;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.Assesment.Application.Middleware;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<AlertApiSettings>(config.GetSection("AlertApiSettings").Bind);

        services.AddDbContext<AppDbContext>();

        services.AddScoped<IAlertRepository, AlertRepository>();
        services.AddScoped<IAlertApiService, AlertApiService>();
        services.AddScoped<IAlertAppService, AlertAppService>();
        services.AddScoped<ILoadAlertJob, LoadAlertJob>();

        services.AddAutoMapper(typeof(AlertProfile), typeof(AlertApiProfile));
    }
}

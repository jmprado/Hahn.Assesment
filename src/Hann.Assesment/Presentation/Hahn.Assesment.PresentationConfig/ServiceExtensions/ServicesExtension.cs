using Hahn.Assesment.Application.Mapping;
using Hahn.Assesment.Application.Services;
using Hahn.Assesment.Persistence.ExternalServices.AlertApi;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.Assesment.Presentation.Config.ServiceExtensions;

public static class ServicesExtension
{
    public static void ConfigureAppServices(this IServiceCollection services, IConfiguration config)
    {
        // Add the AlertApiSettings configuration
        services.Configure<ApiSettings>(config.GetSection("AlertApiSettings").Bind);

        services.AddScoped<IAlertRepository, AlertRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();

        services.AddScoped<IApiService, ApiService>();
        services.AddScoped<IAlertService, AlertService>();

        services.AddAutoMapper(typeof(AlertAppProfile), typeof(AlertApiProfile));
    }
}

using Hahn.Assesment.Application.Mapping;
using Hahn.Assesment.Application.Services;
using Hahn.Assesment.Infrastructure;
using Hahn.Assesment.Persistence.ExternalServices.AlertApi;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Assesment.WebAPI.ServiceExtensions;

public static class AppExtensions
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<ApiSettings>(config.GetSection("AlertApiSettings").Bind);

        services.AddDbContext<AppDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("AlertDb"));
        });

        services.AddScoped<IAlertRepository, AlertRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();

        services.AddScoped<IApiService, ApiService>();
        services.AddScoped<IAlertService, AlertService>();

        services.AddAutoMapper(typeof(AlertAppProfile), typeof(AlertApiProfile));
    }
}

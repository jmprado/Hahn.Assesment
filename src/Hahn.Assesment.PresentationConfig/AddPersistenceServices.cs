using Microsoft.Extensions.DependencyInjection;

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

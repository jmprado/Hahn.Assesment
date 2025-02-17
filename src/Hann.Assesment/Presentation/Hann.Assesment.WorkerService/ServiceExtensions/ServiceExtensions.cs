using Hahn.Assesment.Application.Mapping;
using Hahn.Assesment.Application.Services;
using Hahn.Assesment.Hangfire;
using Hahn.Assesment.Infrastructure;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;
using Hahn.Assesment.Persistence.Services.AlertApi;

namespace Hahn.Assesment.WorkerService.ServiceExtensions;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<AlertApiSettings>(config.GetSection("AlertApiSettings").Bind);

        services.AddDbContext<AppDbContext>();

        services.AddScoped<IAlertRepository, AlertRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();

        services.AddScoped<IAlertApiService, AlertApiService>();
        services.AddScoped<IAlertAppService, AlertAppService>();

        services.AddScoped<IJobsWorker, JobsWorker>();

        services.AddAutoMapper(typeof(AlertProfile), typeof(AlertApiProfile));
    }
}

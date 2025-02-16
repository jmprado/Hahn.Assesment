using Hahn.Assesment.Application.Services.AlertApp;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace Hahn.Assesment.Appliction.Services.Hangfire;

public class HangfireJobs : IHangfireJobs
{
    private readonly string _connectionString;
    private readonly IAlertAppService _alertAppService;

    public HangfireJobs(IConfiguration configuration, IAlertAppService alertAppService)
    {
        _connectionString = configuration.GetConnectionString("HangfireInitDb")!;

        if (_connectionString == null)
        {
            throw new ArgumentException("Hangfire connection string not found.");
        }

        _alertAppService = alertAppService;
    }

    public void AddRecurringJob()
    {
        // Left for testing hangfire implementation 
        // BackgroundJob.Enqueue(() => _alertAppService.LoadAlertDataAsync());

        // Add a recurring job to load alert data every hour
        RecurringJob.AddOrUpdate("LoadAlertJob", () => _alertAppService.LoadAlertDataAsync(), "0 * * * *");
    }
}

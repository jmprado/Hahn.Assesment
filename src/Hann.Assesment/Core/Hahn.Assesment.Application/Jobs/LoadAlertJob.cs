using Hahn.Assesment.Application.Services.AlertApp;
using Hangfire;

namespace Hahn.Assesment.Application.Jobs;

public class LoadAlertJob : ILoadAlertJob
{
    private readonly IAlertAppService _alertAppService;

    public LoadAlertJob(IAlertAppService alertAppService)
    {
        _alertAppService = alertAppService;
    }

    public void AddRecurringJob()
    {
        RecurringJob.AddOrUpdate("LoadAlertJob", () => _alertAppService.LoadAlertDataAsync(), "* * * * *");
    }
}

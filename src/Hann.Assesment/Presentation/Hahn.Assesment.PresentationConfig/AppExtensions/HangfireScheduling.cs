using Hahn.Assesment.Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.Assesment.Presentation.Config.AppExtensions;

public static class HangfireScheduling
{
    public static void ScheduleJobs(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var loadAlertJob = scope.ServiceProvider.GetRequiredService<IJobScheduling>();
        loadAlertJob?.AddAlertRecurringJob();
    }
}

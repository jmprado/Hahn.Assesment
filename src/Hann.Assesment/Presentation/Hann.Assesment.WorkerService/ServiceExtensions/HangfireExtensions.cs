using Hahn.Assesment.Hangfire;

namespace Hahn.Assesment.WorkerService.ServiceExtensions
{
    public static class HangfireExtensions
    {
        public static void AddHangfireAlertRecurringJob(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var loadAlertJob = scope.ServiceProvider.GetRequiredService<IJobScheduling>();
            loadAlertJob?.AddAlertRecurringJob();
        }
    }
}
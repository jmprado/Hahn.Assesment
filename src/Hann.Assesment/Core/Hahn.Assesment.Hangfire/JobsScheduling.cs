using Hahn.Assesment.Application.Services;
using Hangfire;
using Microsoft.Extensions.Options;

namespace Hahn.Assesment.Hangfire
{
    public class JobsScheduling : IJobScheduling
    {
        private readonly IAlertService _alertService;
        private readonly JobSettings _jobSettings;

        public JobsScheduling(IAlertService alertService, IOptions<JobSettings> options)
        {
            _jobSettings = options.Value;
            _alertService = alertService;
        }

        public void AddAlertRecurringJob()
        {
            // Add a job to seed data on startup
            BackgroundJob.Enqueue(() => LoadAlertDataAsync());

            // Add a recurring job to load alert data every hour
            RecurringJob.AddOrUpdate("LoadAlertJob", () => LoadAlertDataAsync(), _jobSettings.CronExpression);
        }

        public async Task LoadAlertDataAsync()
        {
            var alertData = await _alertService.LoadApiDataAsync();
            if (alertData == null)
                throw new ArgumentNullException(nameof(alertData));

            var alertId = await _alertService.AddAlertAsync(alertData);

            if (alertData.AlertCategories == null)
                throw new ArgumentNullException(nameof(alertData.AlertCategories));

            BackgroundJob.Enqueue(() => _alertService.AddCategoriesAsync(alertId, alertData.AlertCategories));

            if (alertData.AlertReports == null)
                throw new ArgumentNullException(nameof(alertData.AlertReports));

            foreach (var report in alertData.AlertReports)
            {
                BackgroundJob.Enqueue(() => _alertService.AddReportAsync(alertId, report));
            }
        }
    }
}

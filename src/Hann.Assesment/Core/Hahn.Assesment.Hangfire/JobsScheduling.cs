using AutoMapper;
using Hahn.Assesment.Application.Services;
using Hangfire;

namespace Hahn.Assesment.Hangfire
{
    public class JobsScheduling : IJobScheduling
    {
        private readonly IAlertService _alertService;
        private readonly IMapper _mapper;

        public JobsScheduling(IAlertService alertService)
        {
            _alertService = alertService;
        }

        public void AddAlertRecurringJob()
        {
            // Left for testing hangfire implementation 
            BackgroundJob.Enqueue(() => LoadAlertDataAsync());

            // Add a recurring job to load alert data every hour
            RecurringJob.AddOrUpdate("LoadAlertJob", () => LoadAlertDataAsync(), "0 * * * *");
        }

        public async Task LoadAlertDataAsync()
        {
            var alertData = await _alertService.LoadApiDataAsync();
            if (alertData == null)
                throw new ArgumentNullException(nameof(alertData));

            var alertId = await _alertService.AddAlertAsync(alertData);

            BackgroundJob.Enqueue(() => _alertService.AddCategoriesAsync(alertId, alertData.AlertCategories));

            foreach (var report in alertData.AlertReports)
            {
                BackgroundJob.Enqueue(() => _alertService.AddReportAsync(alertId, report));
            }
        }
    }
}

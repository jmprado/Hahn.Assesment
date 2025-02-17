using AutoMapper;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Persistence.Repositories.AlertRepository;
using Hahn.Assesment.Persistence.Repositories.Category;
using Hahn.Assesment.Persistence.Repositories.Report;
using Hahn.Assesment.Persistence.Services.AlertApi;
using Hangfire;

namespace Hahn.Assesment.Hangfire
{
    public class JobsWorker : IJobsWorker
    {
        private readonly IAlertApiService _alertApiService;
        private readonly IAlertRepository _alertRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public JobsWorker(IAlertApiService alertApiService, IAlertRepository alertRepository, ICategoryRepository categoryRepository, IReportRepository reportRepository, IMapper mapper)
        {
            _alertApiService = alertApiService;
            _alertRepository = alertRepository;
            _categoryRepository = categoryRepository;
            _reportRepository = reportRepository;
            _mapper = mapper;
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
            var alertData = await _alertApiService.GetAlertDataAsync();
            if (alertData == null)
                throw new ArgumentNullException(nameof(alertData));

            var alertId = await _alertRepository.AddAlertAsync(alertData);
            var alertCategories = _mapper.Map<IEnumerable<AlertCategory>>(alertData.AlertCategories);

            foreach (var category in alertCategories)
                category.AlertId = alertId;

            BackgroundJob.Enqueue(() => _categoryRepository.AddCategoriesAsync(alertCategories));

            var alertReports = _mapper.Map<IEnumerable<AlertReport>>(alertData.AlertReports);

            foreach (var report in alertReports)
            {
                report.AlertId = alertId;
                BackgroundJob.Enqueue(() => _reportRepository.AddReportAsync(report));
            }
        }
    }
}

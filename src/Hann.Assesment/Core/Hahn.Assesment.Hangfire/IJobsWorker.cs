namespace Hahn.Assesment.Hangfire
{
    public interface IJobsWorker
    {
        void AddAlertRecurringJob();
        Task LoadAlertDataAsync();
    }
}
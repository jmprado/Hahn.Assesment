namespace Hahn.Assesment.Hangfire
{
    public interface IJobScheduling
    {
        void AddAlertRecurringJob();
        Task LoadAlertDataAsync();
    }
}
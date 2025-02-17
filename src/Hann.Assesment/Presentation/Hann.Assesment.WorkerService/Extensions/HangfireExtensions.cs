using Hahn.Assesment.Hangfire;
using Microsoft.Data.SqlClient;

public static class HangfireExtensions
{
    public static void AddHangfireAlertRecurringJob(this IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var loadAlertJob = scope.ServiceProvider.GetRequiredService<IJobsWorker>();
        loadAlertJob?.AddAlertRecurringJob();
    }

    public static void CreateHangfireDb(this IConfiguration configuration, string hangfireDbName)
    {
        using var conn = new SqlConnection(string.Format(configuration.GetConnectionString($"{hangfireDbName}InitDb")!));
        conn.Open();

        using var command = new SqlCommand(string.Format(
            @"IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}') 
                                    create database [{0}];
                      ", hangfireDbName), conn);
        command.ExecuteNonQuery();
    }
}
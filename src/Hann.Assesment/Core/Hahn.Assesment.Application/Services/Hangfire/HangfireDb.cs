using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Hahn.Assesment.Appliction.Services.Hangfire;

public class HangfireDb : IHangfireDb
{
    private readonly string _connectionString;

    public HangfireDb(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("HangfireInitDb")!;

        if (_connectionString == null)
        {
            throw new ArgumentException("Hangfire connection string not found.");
        }
    }

    public void CreateDatabase(IConfiguration configuration)
    {
        var sql = @"
                IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Hangfire')
                BEGIN
                    CREATE DATABASE Hangfire;
                END";

        Log.Information("Creating Hangfire database...");

        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = sql;
        command.ExecuteNonQuery();
        connection.Close();
    }
}

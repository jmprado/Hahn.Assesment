using Microsoft.Extensions.Configuration;

namespace Hahn.Assesment.Appliction.Services.Hangfire;

public interface IHangfireDb
{
    void CreateDatabase(IConfiguration configuration);
}
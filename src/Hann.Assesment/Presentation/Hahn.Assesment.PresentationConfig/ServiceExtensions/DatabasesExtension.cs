using Hahn.Assesment.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.Assesment.Presentation.Config.ServiceExtensions;

public static class DatabasesExtension
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("AlertDb"));
        });
    }
}

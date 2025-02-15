using Hahn.Assesment.Domain;
using Hahn.Assesment.Domain.Entities;
using Hahn.Assesment.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hahn.Assesment.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Alerts> WeatherSeverityAlerts { get; set; }
        public DbSet<AlertCategory> SeverityCategories { get; set; }
        public DbSet<AlertReport> SeverityReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("SeverityAlertDb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeatherSeverityAlertConfiguration());
            modelBuilder.ApplyConfiguration(new AlertCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new AlertReportConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}

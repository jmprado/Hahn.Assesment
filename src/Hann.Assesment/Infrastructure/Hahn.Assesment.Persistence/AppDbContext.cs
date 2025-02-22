using Hahn.Assesment.Domain.Models.Entities;
using Hahn.Assesment.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hahn.Assesment.Infrastructure
{
    public class AppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<AlertEntity> Alerts { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureEntities();
            base.OnModelCreating(modelBuilder);
        }
    }
}

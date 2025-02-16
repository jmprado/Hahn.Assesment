﻿using Hahn.Assesment.Domain.Entities;
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
        public DbSet<AlertCategory> AlertCategories { get; set; }
        public DbSet<AlertReport> AlertyReports { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("AlertAppDb");
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

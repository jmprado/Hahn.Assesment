using Hahn.Assesment.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Assesment.Persistence.Configurations;

public static class ModelBuilderExtensions
{
    public static void ConfigureEntities(this ModelBuilder modelBuilder)
    {
        // Alerts table
        modelBuilder.Entity<AlertEntity>(builder =>
        {
            builder.ToTable("Alerts");

            builder.Property(w => w.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(w => w.Id);

            builder.Property(w => w.UpdatedAt)
                .IsRequired();

            builder.Property(w => w.Start)
                .IsRequired();

            builder.Property(w => w.End)
                .IsRequired();

            builder.Property(w => w.WindowsSizeHours)
                .IsRequired();

            builder.HasMany(w => w.AlertCategories)
                .WithOne()
                .HasForeignKey(w => w.AlertId)
                .HasPrincipalKey(w => w.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(w => w.AlertReports)
                .WithOne()
                .HasForeignKey(w => w.AlertId)
                .HasPrincipalKey(w => w.Id)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // Categories table
        modelBuilder.Entity<CategoryEntity>(builder =>
        {
            builder.ToTable("AlertCategories");

            builder.Property(w => w.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(w => w.Id);

            builder.Property(w => w.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.Condition)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(w => w.AlertId)
                .IsRequired();
        });

        // Reports table
        modelBuilder.Entity<ReportEntity>(builder =>
        {
            builder.ToTable("AlertReports");

            builder.Property(w => w.Id)
                .ValueGeneratedOnAdd();

            builder.HasKey(w => w.Id);

            builder.Property(w => w.AlertId)
                .IsRequired();

            builder.Property(w => w.ReportDate)
                .IsRequired();

            builder.Property(w => w.Lat)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(w => w.Lon)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(w => w.Place)
                .HasMaxLength(200);

            builder.Property(w => w.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(w => w.Condition)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(w => w.LikeCount)
                .IsRequired();

            builder.Property(w => w.ImageUrl)
                .HasMaxLength(500);

            builder.Property(w => w.ImageThumbUrl)
                .HasMaxLength(500);

            builder.Property(w => w.ImageMediumUrl)
                .HasMaxLength(500);

            builder.Property(w => w.BlurHash)
                .HasMaxLength(100);

            builder.HasIndex(w => w.Category)
                .HasDatabaseName("IX_SeverityReport_Category");
        });
    }
}
using Hahn.Assesment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.Assesment.Infrastructure.Configurations;

public class WeatherSeverityAlertConfiguration : IEntityTypeConfiguration<AlertEntity>
{
    public void Configure(EntityTypeBuilder<AlertEntity> builder)
    {
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
    }
}
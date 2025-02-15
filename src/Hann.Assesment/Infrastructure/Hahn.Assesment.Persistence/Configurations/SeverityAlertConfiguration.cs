using Hahn.Assesment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.Assesment.Infrastructure.Configurations;

public class WeatherSeverityAlertConfiguration : IEntityTypeConfiguration<SeverityAlert>
{
    public void Configure(EntityTypeBuilder<SeverityAlert> builder)
    {
        builder.HasKey(w => w.Id);

        builder.Property(w => w.UpdatedAt)
            .IsRequired();

        builder.Property(w => w.Start)
            .IsRequired();

        builder.Property(w => w.End)
            .IsRequired();

        builder.Property(w => w.WindowsSizeHours)
            .IsRequired();
    }
}
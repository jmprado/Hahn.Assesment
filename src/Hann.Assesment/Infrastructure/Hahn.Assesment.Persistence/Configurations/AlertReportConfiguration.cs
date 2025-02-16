using Hahn.Assesment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.Assesment.Infrastructure.Configurations;

public class AlertReportConfiguration : IEntityTypeConfiguration<AlertReport>
{
    public void Configure(EntityTypeBuilder<AlertReport> builder)
    {
        builder.Property(w => w.Id)
            .ValueGeneratedOnAdd();

        builder.HasKey(w => w.Id);

        builder.Property(w => w.AlertId)
            .IsRequired();

        builder.Property(w => w.AlertDate)
            .IsRequired();

        builder.Property(w => w.Lat)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(w => w.Lon)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(w => w.Place)
            .IsRequired()
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

        builder.Property(w => w.AlertId)
            .IsRequired();

        builder.HasIndex(w => w.Category)
            .HasDatabaseName("IX_SeverityReport_Category");
    }
}

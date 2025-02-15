using Hahn.Assesment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.Assesment.Infrastructure.Configurations;

public class AlertReportConfiguration : IEntityTypeConfiguration<AlertReport>
{
    public void Configure(EntityTypeBuilder<AlertReport> builder)
    {
        builder.HasKey(sr => sr.Id);

        builder.Property(sr => sr.Timestamp)
            .IsRequired();

        builder.Property(sr => sr.Lat)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(sr => sr.Lon)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(sr => sr.Place)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(sr => sr.Category)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(sr => sr.Condition)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(sr => sr.LikeCount)
            .IsRequired();

        builder.Property(sr => sr.ImageUrl)
            .HasMaxLength(500);

        builder.Property(sr => sr.ImageThumbUrl)
            .HasMaxLength(500);

        builder.Property(sr => sr.ImageMediumUrl)
            .HasMaxLength(500);

        builder.Property(sr => sr.BlurHash)
            .HasMaxLength(100);

        builder.Property(sr => sr.SeverityAlertId)
            .IsRequired();

        builder.HasOne(sr => sr.SeverityAlert)
            .WithMany()
            .HasForeignKey(sr => sr.SeverityAlertId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(sr => sr.Category)
            .HasDatabaseName("IX_SeverityReport_Category");
    }
}

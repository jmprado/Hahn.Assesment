using Hahn.Assesment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.Assesment.Infrastructure.Configurations
{
    public class SeverityCategoryConfiguration : IEntityTypeConfiguration<SeverityCategory>
    {
        public void Configure(EntityTypeBuilder<SeverityCategory> builder)
        {
            builder.HasKey(sc => sc.Category);

            builder.Property(sc => sc.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sc => sc.Condition)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(sc => sc.SeverityAlertId)
                .IsRequired();

            builder.HasOne(sc => sc.SeverityAlert)
                .WithMany()
                .HasForeignKey(sc => sc.SeverityAlertId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

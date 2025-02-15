using Hahn.Assesment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.Assesment.Infrastructure.Configurations
{
    public class AlertCategoryConfiguration : IEntityTypeConfiguration<AlertCategory>
    {
        public void Configure(EntityTypeBuilder<AlertCategory> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Category)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sc => sc.Condition)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(sc => sc.AlertId)
                .IsRequired();

            builder.Property(sr => sr.AlertId)
                .IsRequired();
        }
    }
}

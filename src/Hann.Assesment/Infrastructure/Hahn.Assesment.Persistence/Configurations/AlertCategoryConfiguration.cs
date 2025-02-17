using Hahn.Assesment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.Assesment.Infrastructure.Configurations
{
    public class AlertCategoryConfiguration : IEntityTypeConfiguration<AlertCategory>
    {
        public void Configure(EntityTypeBuilder<AlertCategory> builder)
        {
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
        }
    }
}

using Hahn.Assesment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hahn.Assesment.Infrastructure.Configurations.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyDefaultValues(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlertEntity>()
            .Property(a => a.Id)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<AlertCategory>()
            .Property(a => a.Id)
            .HasDefaultValueSql("NEWID()");

        modelBuilder.Entity<AlertReport>()
            .Property(a => a.Id)
            .HasDefaultValueSql("NEWID()");
    }
}
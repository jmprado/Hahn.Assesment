﻿// <auto-generated />
using System;
using Hahn.Assesment.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hahn.Assesment.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250215171934_AlertAppDbContext")]
    partial class AlertAppDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hahn.Assesment.Domain.Entities.Alert", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("End")
                        .HasColumnType("int");

                    b.Property<int>("Start")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WindowsSizeHours")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WeatherSeverityAlerts");
                });

            modelBuilder.Entity("Hahn.Assesment.Domain.Entities.AlertCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AlertId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("SeverityAlertId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AlertId");

                    b.HasIndex("SeverityAlertId");

                    b.ToTable("SeverityCategories");
                });

            modelBuilder.Entity("Hahn.Assesment.Domain.Entities.AlertReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<Guid?>("AlertId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BlurHash")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Condition")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.PrimitiveCollection<string>("ExtraAttribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageMediumUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("ImageThumbHeight")
                        .HasColumnType("int");

                    b.Property<string>("ImageThumbUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("ImageThumbWidth")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Lat")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LikeCount")
                        .HasColumnType("int");

                    b.Property<string>("Lon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("SeverityAlertId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Timestamp")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlertId");

                    b.HasIndex("Category")
                        .HasDatabaseName("IX_SeverityReport_Category");

                    b.HasIndex("SeverityAlertId");

                    b.ToTable("SeverityReports");
                });

            modelBuilder.Entity("Hahn.Assesment.Domain.Entities.AlertCategory", b =>
                {
                    b.HasOne("Hahn.Assesment.Domain.Entities.Alert", null)
                        .WithMany("SeverityCategories")
                        .HasForeignKey("AlertId");

                    b.HasOne("Hahn.Assesment.Domain.Entities.Alert", "SeverityAlert")
                        .WithMany()
                        .HasForeignKey("SeverityAlertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SeverityAlert");
                });

            modelBuilder.Entity("Hahn.Assesment.Domain.Entities.AlertReport", b =>
                {
                    b.HasOne("Hahn.Assesment.Domain.Entities.Alert", null)
                        .WithMany("SeverityReport")
                        .HasForeignKey("AlertId");

                    b.HasOne("Hahn.Assesment.Domain.Entities.Alert", "SeverityAlert")
                        .WithMany()
                        .HasForeignKey("SeverityAlertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SeverityAlert");
                });

            modelBuilder.Entity("Hahn.Assesment.Domain.Entities.Alert", b =>
                {
                    b.Navigation("SeverityCategories");

                    b.Navigation("SeverityReport");
                });
#pragma warning restore 612, 618
        }
    }
}

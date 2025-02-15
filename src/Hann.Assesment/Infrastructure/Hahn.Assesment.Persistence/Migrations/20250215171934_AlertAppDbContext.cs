using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hahn.Assesment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AlertAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherSeverityAlerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start = table.Column<int>(type: "int", nullable: false),
                    End = table.Column<int>(type: "int", nullable: false),
                    WindowsSizeHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherSeverityAlerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeverityCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SeverityAlertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeverityCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeverityCategories_WeatherSeverityAlerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "WeatherSeverityAlerts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeverityCategories_WeatherSeverityAlerts_SeverityAlertId",
                        column: x => x.SeverityAlertId,
                        principalTable: "WeatherSeverityAlerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeverityReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Timestamp = table.Column<int>(type: "int", nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Lon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Place = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ExtraAttribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageThumbUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageMediumUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BlurHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImageThumbWidth = table.Column<int>(type: "int", nullable: true),
                    ImageThumbHeight = table.Column<int>(type: "int", nullable: true),
                    SeverityAlertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeverityReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeverityReports_WeatherSeverityAlerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "WeatherSeverityAlerts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SeverityReports_WeatherSeverityAlerts_SeverityAlertId",
                        column: x => x.SeverityAlertId,
                        principalTable: "WeatherSeverityAlerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeverityCategories_AlertId",
                table: "SeverityCategories",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_SeverityCategories_SeverityAlertId",
                table: "SeverityCategories",
                column: "SeverityAlertId");

            migrationBuilder.CreateIndex(
                name: "IX_SeverityReport_Category",
                table: "SeverityReports",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_SeverityReports_AlertId",
                table: "SeverityReports",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_SeverityReports_SeverityAlertId",
                table: "SeverityReports",
                column: "SeverityAlertId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeverityCategories");

            migrationBuilder.DropTable(
                name: "SeverityReports");

            migrationBuilder.DropTable(
                name: "WeatherSeverityAlerts");
        }
    }
}

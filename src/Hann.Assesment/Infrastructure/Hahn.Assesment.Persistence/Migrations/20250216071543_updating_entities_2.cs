using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hahn.Assesment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updating_entities_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WindowsSizeHours = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AlertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertCategories_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertCategories_Alerts_AlertsId",
                        column: x => x.AlertsId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlertReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    AlertDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    AlertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlertsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertReports_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertReports_Alerts_AlertsId",
                        column: x => x.AlertsId,
                        principalTable: "Alerts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlertCategories_AlertId",
                table: "AlertCategories",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertCategories_AlertsId",
                table: "AlertCategories",
                column: "AlertsId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertReports_AlertId",
                table: "AlertReports",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertReports_AlertsId",
                table: "AlertReports",
                column: "AlertsId");

            migrationBuilder.CreateIndex(
                name: "IX_SeverityReport_Category",
                table: "AlertReports",
                column: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertCategories");

            migrationBuilder.DropTable(
                name: "AlertReports");

            migrationBuilder.DropTable(
                name: "Alerts");
        }
    }
}

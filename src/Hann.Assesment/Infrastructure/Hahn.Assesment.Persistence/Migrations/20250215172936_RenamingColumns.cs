using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hahn.Assesment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamingColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeverityCategories_WeatherSeverityAlerts_AlertId",
                table: "SeverityCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SeverityCategories_WeatherSeverityAlerts_SeverityAlertId",
                table: "SeverityCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SeverityReports_WeatherSeverityAlerts_AlertId",
                table: "SeverityReports");

            migrationBuilder.DropForeignKey(
                name: "FK_SeverityReports_WeatherSeverityAlerts_SeverityAlertId",
                table: "SeverityReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WeatherSeverityAlerts",
                table: "WeatherSeverityAlerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeverityReports",
                table: "SeverityReports");

            migrationBuilder.DropIndex(
                name: "IX_SeverityReports_SeverityAlertId",
                table: "SeverityReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SeverityCategories",
                table: "SeverityCategories");

            migrationBuilder.DropColumn(
                name: "SeverityAlertId",
                table: "SeverityReports");

            migrationBuilder.RenameTable(
                name: "WeatherSeverityAlerts",
                newName: "Alerts");

            migrationBuilder.RenameTable(
                name: "SeverityReports",
                newName: "AlertyReports");

            migrationBuilder.RenameTable(
                name: "SeverityCategories",
                newName: "AlertCategories");

            migrationBuilder.RenameIndex(
                name: "IX_SeverityReports_AlertId",
                table: "AlertyReports",
                newName: "IX_AlertyReports_AlertId");

            migrationBuilder.RenameIndex(
                name: "IX_SeverityCategories_SeverityAlertId",
                table: "AlertCategories",
                newName: "IX_AlertCategories_SeverityAlertId");

            migrationBuilder.RenameIndex(
                name: "IX_SeverityCategories_AlertId",
                table: "AlertCategories",
                newName: "IX_AlertCategories_AlertId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlertId",
                table: "AlertyReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AlertId1",
                table: "AlertyReports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertyReports",
                table: "AlertyReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlertCategories",
                table: "AlertCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AlertyReports_AlertId1",
                table: "AlertyReports",
                column: "AlertId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertCategories_Alerts_AlertId",
                table: "AlertCategories",
                column: "AlertId",
                principalTable: "Alerts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertCategories_Alerts_SeverityAlertId",
                table: "AlertCategories",
                column: "SeverityAlertId",
                principalTable: "Alerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertyReports_Alerts_AlertId",
                table: "AlertyReports",
                column: "AlertId",
                principalTable: "Alerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertyReports_Alerts_AlertId1",
                table: "AlertyReports",
                column: "AlertId1",
                principalTable: "Alerts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertCategories_Alerts_AlertId",
                table: "AlertCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertCategories_Alerts_SeverityAlertId",
                table: "AlertCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertyReports_Alerts_AlertId",
                table: "AlertyReports");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertyReports_Alerts_AlertId1",
                table: "AlertyReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertyReports",
                table: "AlertyReports");

            migrationBuilder.DropIndex(
                name: "IX_AlertyReports_AlertId1",
                table: "AlertyReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alerts",
                table: "Alerts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlertCategories",
                table: "AlertCategories");

            migrationBuilder.DropColumn(
                name: "AlertId1",
                table: "AlertyReports");

            migrationBuilder.RenameTable(
                name: "AlertyReports",
                newName: "SeverityReports");

            migrationBuilder.RenameTable(
                name: "Alerts",
                newName: "WeatherSeverityAlerts");

            migrationBuilder.RenameTable(
                name: "AlertCategories",
                newName: "SeverityCategories");

            migrationBuilder.RenameIndex(
                name: "IX_AlertyReports_AlertId",
                table: "SeverityReports",
                newName: "IX_SeverityReports_AlertId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertCategories_SeverityAlertId",
                table: "SeverityCategories",
                newName: "IX_SeverityCategories_SeverityAlertId");

            migrationBuilder.RenameIndex(
                name: "IX_AlertCategories_AlertId",
                table: "SeverityCategories",
                newName: "IX_SeverityCategories_AlertId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlertId",
                table: "SeverityReports",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SeverityAlertId",
                table: "SeverityReports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeverityReports",
                table: "SeverityReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WeatherSeverityAlerts",
                table: "WeatherSeverityAlerts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SeverityCategories",
                table: "SeverityCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SeverityReports_SeverityAlertId",
                table: "SeverityReports",
                column: "SeverityAlertId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeverityCategories_WeatherSeverityAlerts_AlertId",
                table: "SeverityCategories",
                column: "AlertId",
                principalTable: "WeatherSeverityAlerts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeverityCategories_WeatherSeverityAlerts_SeverityAlertId",
                table: "SeverityCategories",
                column: "SeverityAlertId",
                principalTable: "WeatherSeverityAlerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SeverityReports_WeatherSeverityAlerts_AlertId",
                table: "SeverityReports",
                column: "AlertId",
                principalTable: "WeatherSeverityAlerts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SeverityReports_WeatherSeverityAlerts_SeverityAlertId",
                table: "SeverityReports",
                column: "SeverityAlertId",
                principalTable: "WeatherSeverityAlerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hahn.Assesment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamingColumns_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertCategories_Alerts_AlertId1",
                table: "AlertCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertyReports_Alerts_AlertId1",
                table: "AlertyReports");

            migrationBuilder.DropIndex(
                name: "IX_AlertyReports_AlertId1",
                table: "AlertyReports");

            migrationBuilder.DropIndex(
                name: "IX_AlertCategories_AlertId1",
                table: "AlertCategories");

            migrationBuilder.DropColumn(
                name: "AlertId1",
                table: "AlertyReports");

            migrationBuilder.DropColumn(
                name: "AlertId1",
                table: "AlertCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AlertId1",
                table: "AlertyReports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AlertId1",
                table: "AlertCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlertyReports_AlertId1",
                table: "AlertyReports",
                column: "AlertId1");

            migrationBuilder.CreateIndex(
                name: "IX_AlertCategories_AlertId1",
                table: "AlertCategories",
                column: "AlertId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertCategories_Alerts_AlertId1",
                table: "AlertCategories",
                column: "AlertId1",
                principalTable: "Alerts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertyReports_Alerts_AlertId1",
                table: "AlertyReports",
                column: "AlertId1",
                principalTable: "Alerts",
                principalColumn: "Id");
        }
    }
}

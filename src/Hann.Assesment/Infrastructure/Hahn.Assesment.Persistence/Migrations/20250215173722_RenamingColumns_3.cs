using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hahn.Assesment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenamingColumns_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlertCategories_Alerts_AlertId",
                table: "AlertCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_AlertCategories_Alerts_SeverityAlertId",
                table: "AlertCategories");

            migrationBuilder.DropIndex(
                name: "IX_AlertCategories_SeverityAlertId",
                table: "AlertCategories");

            migrationBuilder.DropColumn(
                name: "SeverityAlertId",
                table: "AlertCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlertId",
                table: "AlertCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AlertId1",
                table: "AlertCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlertCategories_AlertId1",
                table: "AlertCategories",
                column: "AlertId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AlertCategories_Alerts_AlertId",
                table: "AlertCategories",
                column: "AlertId",
                principalTable: "Alerts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AlertCategories_Alerts_AlertId1",
                table: "AlertCategories",
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
                name: "FK_AlertCategories_Alerts_AlertId1",
                table: "AlertCategories");

            migrationBuilder.DropIndex(
                name: "IX_AlertCategories_AlertId1",
                table: "AlertCategories");

            migrationBuilder.DropColumn(
                name: "AlertId1",
                table: "AlertCategories");

            migrationBuilder.AlterColumn<Guid>(
                name: "AlertId",
                table: "AlertCategories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SeverityAlertId",
                table: "AlertCategories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AlertCategories_SeverityAlertId",
                table: "AlertCategories",
                column: "SeverityAlertId");

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
        }
    }
}

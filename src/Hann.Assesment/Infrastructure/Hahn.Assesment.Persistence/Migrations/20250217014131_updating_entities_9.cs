using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hahn.Assesment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updating_entities_9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlertDate",
                table: "AlertReports",
                newName: "ReportDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReportDate",
                table: "AlertReports",
                newName: "AlertDate");
        }
    }
}

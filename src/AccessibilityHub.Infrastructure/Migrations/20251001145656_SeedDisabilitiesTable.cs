using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessibilityHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDisabilitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Disabilities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "...", "Hearing" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Disabilities",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

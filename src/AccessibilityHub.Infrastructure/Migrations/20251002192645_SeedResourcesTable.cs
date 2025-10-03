using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccessibilityHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedResourcesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Category", "Description", "DisabilityId", "Name", "Url" },
                values: new object[] { 1, "Holding Company", "...", 1, "Sonova", "https://www.sonova.com/en" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Resources",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

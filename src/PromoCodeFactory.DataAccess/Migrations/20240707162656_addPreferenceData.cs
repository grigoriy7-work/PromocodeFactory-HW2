using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromoCodeFactory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addPreferenceData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "Name", "PromoCodeId" },
                values: new object[,]
                {
                    { new Guid("6fe5b5bc-7300-427d-b0fb-7c75bc1fed16"), "Семья", null },
                    { new Guid("7025c2b8-edb6-4eb7-b00b-7321dd46501b"), "Дети", null },
                    { new Guid("8a9e725a-a2fe-47d6-8612-c0e4a79e5dc5"), "Театр", null },
                    { new Guid("8cc721d3-7c29-4993-8353-f86fddd7cdc0"), "Бизнес", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: new Guid("6fe5b5bc-7300-427d-b0fb-7c75bc1fed16"));

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: new Guid("7025c2b8-edb6-4eb7-b00b-7321dd46501b"));

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: new Guid("8a9e725a-a2fe-47d6-8612-c0e4a79e5dc5"));

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: new Guid("8cc721d3-7c29-4993-8353-f86fddd7cdc0"));
        }
    }
}

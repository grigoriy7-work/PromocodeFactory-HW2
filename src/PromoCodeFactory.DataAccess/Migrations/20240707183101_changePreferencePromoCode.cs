using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromoCodeFactory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changePreferencePromoCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_PromoCodes_PromoCodeId",
                table: "Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_PromoCodeId",
                table: "Preferences");

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

            migrationBuilder.DropColumn(
                name: "PromoCodeId",
                table: "Preferences");

            migrationBuilder.AddColumn<Guid>(
                name: "PreferenceId",
                table: "PromoCodes",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_PreferenceId",
                table: "PromoCodes",
                column: "PreferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_PromoCodes_Preferences_PreferenceId",
                table: "PromoCodes",
                column: "PreferenceId",
                principalTable: "Preferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromoCodes_Preferences_PreferenceId",
                table: "PromoCodes");

            migrationBuilder.DropIndex(
                name: "IX_PromoCodes_PreferenceId",
                table: "PromoCodes");

            migrationBuilder.DropColumn(
                name: "PreferenceId",
                table: "PromoCodes");

            migrationBuilder.AddColumn<Guid>(
                name: "PromoCodeId",
                table: "Preferences",
                type: "TEXT",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_PromoCodeId",
                table: "Preferences",
                column: "PromoCodeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_PromoCodes_PromoCodeId",
                table: "Preferences",
                column: "PromoCodeId",
                principalTable: "PromoCodes",
                principalColumn: "Id");
        }
    }
}

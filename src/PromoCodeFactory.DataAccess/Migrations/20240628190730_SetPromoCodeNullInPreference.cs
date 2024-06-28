using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PromoCodeFactory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SetPromoCodeNullInPreference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_PromoCodes_PromoCodeId",
                table: "Preferences");

            migrationBuilder.AlterColumn<Guid>(
                name: "PromoCodeId",
                table: "Preferences",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_PromoCodes_PromoCodeId",
                table: "Preferences",
                column: "PromoCodeId",
                principalTable: "PromoCodes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_PromoCodes_PromoCodeId",
                table: "Preferences");

            migrationBuilder.AlterColumn<Guid>(
                name: "PromoCodeId",
                table: "Preferences",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_PromoCodes_PromoCodeId",
                table: "Preferences",
                column: "PromoCodeId",
                principalTable: "PromoCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

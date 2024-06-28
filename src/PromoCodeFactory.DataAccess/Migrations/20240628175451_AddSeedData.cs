using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromoCodeFactory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Deleted", "Description", "EmployeeId", "Name" },
                values: new object[,]
                {
                    { new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"), false, "Администратор", new Guid("00000000-0000-0000-0000-000000000000"), "Admin" },
                    { new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"), false, "Партнерский менеджер", new Guid("00000000-0000-0000-0000-000000000000"), "PartnerManager" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AppliedPromocodesCount", "Deleted", "Email", "FirstName", "LastName", "PreferenceId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"), 5, false, "owner@somemail.ru", "Иван", "Сергеев", null, new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02") },
                    { new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), 10, false, "andreev@somemail.ru", "Петр", "Андреев", null, new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"));
        }
    }
}

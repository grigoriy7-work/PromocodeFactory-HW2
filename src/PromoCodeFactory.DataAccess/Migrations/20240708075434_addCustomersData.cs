using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromoCodeFactory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addCustomersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("119a2ebc-85e5-43b9-bd7c-097e52196373"), "misato@mail.com", "Мисато", "Кацураги" },
                    { new Guid("2d56645d-84bb-40f5-adbc-6850c2d30ef9"), "shinji@mail.com", "Синдзи", "Икари" },
                    { new Guid("794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8"), "ritsuko@mail.com", "Рицуко", "Акаги" }
                });

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1a40591f-a22c-4300-aefa-29c12a093dd2"), "Театр" },
                    { new Guid("237e6d2d-519a-42a6-859b-2f70ecacfb71"), "Дети" },
                    { new Guid("f1346ed6-d126-4cda-be54-8a37b18d87f9"), "Бизнес" },
                    { new Guid("f6b0e44e-7b9e-4c9c-9fb8-0c86880ebed9"), "Семья" }
                });

            migrationBuilder.InsertData(
                table: "CustomerPreferences",
                columns: new[] { "CustomerId", "PreferenceId" },
                values: new object[,]
                {
                    { new Guid("119a2ebc-85e5-43b9-bd7c-097e52196373"), new Guid("1a40591f-a22c-4300-aefa-29c12a093dd2") },
                    { new Guid("119a2ebc-85e5-43b9-bd7c-097e52196373"), new Guid("237e6d2d-519a-42a6-859b-2f70ecacfb71") },
                    { new Guid("2d56645d-84bb-40f5-adbc-6850c2d30ef9"), new Guid("1a40591f-a22c-4300-aefa-29c12a093dd2") },
                    { new Guid("2d56645d-84bb-40f5-adbc-6850c2d30ef9"), new Guid("f1346ed6-d126-4cda-be54-8a37b18d87f9") },
                    { new Guid("794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8"), new Guid("237e6d2d-519a-42a6-859b-2f70ecacfb71") },
                    { new Guid("794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8"), new Guid("f6b0e44e-7b9e-4c9c-9fb8-0c86880ebed9") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("119a2ebc-85e5-43b9-bd7c-097e52196373"), new Guid("1a40591f-a22c-4300-aefa-29c12a093dd2") });

            migrationBuilder.DeleteData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("119a2ebc-85e5-43b9-bd7c-097e52196373"), new Guid("237e6d2d-519a-42a6-859b-2f70ecacfb71") });

            migrationBuilder.DeleteData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("2d56645d-84bb-40f5-adbc-6850c2d30ef9"), new Guid("1a40591f-a22c-4300-aefa-29c12a093dd2") });

            migrationBuilder.DeleteData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("2d56645d-84bb-40f5-adbc-6850c2d30ef9"), new Guid("f1346ed6-d126-4cda-be54-8a37b18d87f9") });

            migrationBuilder.DeleteData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8"), new Guid("237e6d2d-519a-42a6-859b-2f70ecacfb71") });

            migrationBuilder.DeleteData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8"), new Guid("f6b0e44e-7b9e-4c9c-9fb8-0c86880ebed9") });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("119a2ebc-85e5-43b9-bd7c-097e52196373"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("2d56645d-84bb-40f5-adbc-6850c2d30ef9"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("794d3f49-6ddf-4a4b-9d6b-5c8e164d87f8"));

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: new Guid("1a40591f-a22c-4300-aefa-29c12a093dd2"));

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: new Guid("237e6d2d-519a-42a6-859b-2f70ecacfb71"));

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: new Guid("f1346ed6-d126-4cda-be54-8a37b18d87f9"));

            migrationBuilder.DeleteData(
                table: "Preferences",
                keyColumn: "Id",
                keyValue: new Guid("f6b0e44e-7b9e-4c9c-9fb8-0c86880ebed9"));
        }
    }
}

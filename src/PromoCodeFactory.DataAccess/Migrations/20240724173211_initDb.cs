using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PromoCodeFactory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPreferences",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreferenceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPreferences", x => new { x.CustomerId, x.PreferenceId });
                    table.ForeignKey(
                        name: "FK_CustomerPreferences_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPreferences_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    AppliedPromocodesCount = table.Column<int>(type: "integer", nullable: false),
                    PreferenceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PromoCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ServiceInfo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BeginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PartnerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    PartnerManagerId = table.Column<Guid>(type: "uuid", nullable: true),
                    PreferenceId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoCodes_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromoCodes_Employees_PartnerManagerId",
                        column: x => x.PartnerManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromoCodes_Preferences_PreferenceId",
                        column: x => x.PreferenceId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                table: "Role",
                columns: new[] { "Id", "Description", "EmployeeId", "Name" },
                values: new object[,]
                {
                    { new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02"), "Администратор", new Guid("00000000-0000-0000-0000-000000000000"), "Admin" },
                    { new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665"), "Партнерский менеджер", new Guid("00000000-0000-0000-0000-000000000000"), "PartnerManager" }
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

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AppliedPromocodesCount", "Email", "FirstName", "LastName", "PreferenceId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("451533d5-d8d5-4a11-9c7b-eb9f14e1a32f"), 5, "owner@somemail.ru", "Иван", "Сергеев", null, new Guid("53729686-a368-4eeb-8bfa-cc69b6050d02") },
                    { new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), 10, "andreev@somemail.ru", "Петр", "Андреев", null, new Guid("b0ae7aac-5493-45cd-ad16-87426a5e7665") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPreferences_PreferenceId",
                table: "CustomerPreferences",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PreferenceId",
                table: "Employees",
                column: "PreferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_CustomerId",
                table: "PromoCodes",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_PartnerManagerId",
                table: "PromoCodes",
                column: "PartnerManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodes_PreferenceId",
                table: "PromoCodes",
                column: "PreferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerPreferences");

            migrationBuilder.DropTable(
                name: "PromoCodes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}

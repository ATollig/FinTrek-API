using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinTrek_API.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "0078dd8f-03ac-4168-a369-1d6a20538c1f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "3aecd5c4-03b5-4308-963b-97e01325ab36" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0078dd8f-03ac-4168-a369-1d6a20538c1f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3aecd5c4-03b5-4308-963b-97e01325ab36");

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecordTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecordTypeId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_RecordTypes_RecordTypeId",
                        column: x => x.RecordTypeId,
                        principalTable: "RecordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    DateSet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyPeriod = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budget_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Budget_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubscriptionId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2627edc4-5c6f-4b77-b808-894344c960e4", 0, "b3641cfd-b43e-4746-a43d-c657c06f7b6a", "admin@example.com", true, false, null, "Admin", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOCLO3rri0nBCFXKmxOwF6/SCbgYrn4nSw0F1R/JydfUEw6lZvvgaWOdCH0dgnh7NQ==", null, false, "89f0237c-8657-4de8-bf03-e3474bc675e4", null, "User", false, "admin@example.com" },
                    { "97339b14-11fc-428f-ace6-0c414a220e68", 0, "89c57658-108c-4a0d-babb-cf8aed03b96f", "dev@example.com", true, false, null, "Dev", "DEV@EXAMPLE.COM", "DEV@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIbNFp/GxrUPjLTT+or98an02cRdxfJ9ZlEb4OThwLXvGrpKy46xVAAPKY+7h9CnRg==", null, false, "5e6df8d6-a063-4722-8a00-d268f7a34f8a", null, "User", false, "dev@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "2627edc4-5c6f-4b77-b808-894344c960e4" },
                    { "2", "97339b14-11fc-428f-ace6-0c414a220e68" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_ApplicationUserId",
                table: "Budget",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Budget_CategoryId",
                table: "Budget",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ApplicationUserId",
                table: "Category",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_RecordTypeId",
                table: "Category",
                column: "RecordTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "PaymentTypes");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "RecordTypes");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "2627edc4-5c6f-4b77-b808-894344c960e4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "97339b14-11fc-428f-ace6-0c414a220e68" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2627edc4-5c6f-4b77-b808-894344c960e4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "97339b14-11fc-428f-ace6-0c414a220e68");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubscriptionId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0078dd8f-03ac-4168-a369-1d6a20538c1f", 0, "faeb443e-ecf1-4762-823f-d21c34d533ee", "admin@example.com", true, false, null, "Admin", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEBDMr2Uz48sWX0coMQcTI5krCI43dsusNxAo37cw1GWqAB6e7WRESz7j/GARlH/wrA==", null, false, "07663980-b8eb-45ba-8cef-198277e27484", null, "User", false, "admin@example.com" },
                    { "3aecd5c4-03b5-4308-963b-97e01325ab36", 0, "f03ef3b4-61ef-4440-a78a-2230b1478f9e", "dev@example.com", true, false, null, "Dev", "DEV@EXAMPLE.COM", "DEV@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEzUBtfTX/81XJsF9LyKVZJK5UMGqxkNUjeU6VNo8shxOzToRuna/5aCZ+eKZMjezg==", null, false, "6cb23481-7c55-4662-a856-cf0229935393", null, "User", false, "dev@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "0078dd8f-03ac-4168-a369-1d6a20538c1f" },
                    { "2", "3aecd5c4-03b5-4308-963b-97e01325ab36" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinTrek_API.Migrations
{
    /// <inheritdoc />
    public partial class new2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Budget_AspNetUsers_ApplicationUserId",
                table: "Budget");

            migrationBuilder.DropForeignKey(
                name: "FK_Budget_Category_CategoryId",
                table: "Budget");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_AspNetUsers_ApplicationUserId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_RecordTypes_RecordTypeId",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Budget",
                table: "Budget");

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

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categorys");

            migrationBuilder.RenameTable(
                name: "Budget",
                newName: "Budgets");

            migrationBuilder.RenameIndex(
                name: "IX_Category_RecordTypeId",
                table: "Categorys",
                newName: "IX_Categorys_RecordTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ParentId",
                table: "Categorys",
                newName: "IX_Categorys_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_ApplicationUserId",
                table: "Categorys",
                newName: "IX_Categorys_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Budget_CategoryId",
                table: "Budgets",
                newName: "IX_Budgets_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Budget_ApplicationUserId",
                table: "Budgets",
                newName: "IX_Budgets_ApplicationUserId");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyCodeId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Budgets",
                table: "Budgets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CurrencyCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Savings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GoalReached = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Savings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Savings_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecordDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    RecordTypeId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    PayerId = table.Column<int>(type: "int", nullable: false),
                    PayeeId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CurrencyCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_CurrencyCodes_CurrencyCodeId",
                        column: x => x.CurrencyCodeId,
                        principalTable: "CurrencyCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_Payees_PayeeId",
                        column: x => x.PayeeId,
                        principalTable: "Payees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_Payers_PayerId",
                        column: x => x.PayerId,
                        principalTable: "Payers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Record_RecordTypes_RecordTypeId",
                        column: x => x.RecordTypeId,
                        principalTable: "RecordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SavingRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Claim = table.Column<bool>(type: "bit", nullable: false),
                    SavingId = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavingRecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SavingRecord_Record_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Record",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SavingRecord_Savings_SavingId",
                        column: x => x.SavingId,
                        principalTable: "Savings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrencyCodeId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubscriptionId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "174bdcf5-3c39-4cd9-8e52-48c68765ae71", 0, "01cad31a-c668-4dac-bf5d-50d2fd95a27f", null, "admin@example.com", true, false, null, "Admin", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAENDrH99vAg6RoNht8eC0uy4pZ9qbS0oPHkfH/U37b7C/7Ii5Ds9u5FH+hk1EHWw/MA==", null, false, "7aa142e0-bce9-44da-a9a9-eccd80c70570", null, "User", false, "admin@example.com" },
                    { "1e3fb57c-b184-4362-8ede-2ae912c8ef05", 0, "2066f279-4136-4541-a1e1-c871e704020f", null, "dev@example.com", true, false, null, "Dev", "DEV@EXAMPLE.COM", "DEV@EXAMPLE.COM", "AQAAAAIAAYagAAAAEPuxvVA7WW1bx0qsnGumudd9Qa1Jey+jMI9AwV0tlhBRBf9n/lAusuln+dHBBhOlzg==", null, false, "8bc6a792-2203-4280-bbfa-dccbf47dd12b", null, "User", false, "dev@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "174bdcf5-3c39-4cd9-8e52-48c68765ae71" },
                    { "2", "1e3fb57c-b184-4362-8ede-2ae912c8ef05" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CurrencyCodeId",
                table: "AspNetUsers",
                column: "CurrencyCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_ApplicationUserId",
                table: "Record",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_CategoryId",
                table: "Record",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_CurrencyCodeId",
                table: "Record",
                column: "CurrencyCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_PayeeId",
                table: "Record",
                column: "PayeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_PayerId",
                table: "Record",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_PaymentTypeId",
                table: "Record",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_RecordTypeId",
                table: "Record",
                column: "RecordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingRecord_RecordId",
                table: "SavingRecord",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_SavingRecord_SavingId",
                table: "SavingRecord",
                column: "SavingId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_CategoryId",
                table: "Savings",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_CurrencyCodes_CurrencyCodeId",
                table: "AspNetUsers",
                column: "CurrencyCodeId",
                principalTable: "CurrencyCodes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_AspNetUsers_ApplicationUserId",
                table: "Budgets",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Budgets_Categorys_CategoryId",
                table: "Budgets",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorys_AspNetUsers_ApplicationUserId",
                table: "Categorys",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorys_Categorys_ParentId",
                table: "Categorys",
                column: "ParentId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categorys_RecordTypes_RecordTypeId",
                table: "Categorys",
                column: "RecordTypeId",
                principalTable: "RecordTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_CurrencyCodes_CurrencyCodeId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_AspNetUsers_ApplicationUserId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Budgets_Categorys_CategoryId",
                table: "Budgets");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorys_AspNetUsers_ApplicationUserId",
                table: "Categorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorys_Categorys_ParentId",
                table: "Categorys");

            migrationBuilder.DropForeignKey(
                name: "FK_Categorys_RecordTypes_RecordTypeId",
                table: "Categorys");

            migrationBuilder.DropTable(
                name: "SavingRecord");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "Savings");

            migrationBuilder.DropTable(
                name: "CurrencyCodes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CurrencyCodeId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Budgets",
                table: "Budgets");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "174bdcf5-3c39-4cd9-8e52-48c68765ae71" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "1e3fb57c-b184-4362-8ede-2ae912c8ef05" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "174bdcf5-3c39-4cd9-8e52-48c68765ae71");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e3fb57c-b184-4362-8ede-2ae912c8ef05");

            migrationBuilder.DropColumn(
                name: "CurrencyCodeId",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Budgets",
                newName: "Budget");

            migrationBuilder.RenameIndex(
                name: "IX_Categorys_RecordTypeId",
                table: "Category",
                newName: "IX_Category_RecordTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Categorys_ParentId",
                table: "Category",
                newName: "IX_Category_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Categorys_ApplicationUserId",
                table: "Category",
                newName: "IX_Category_ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_CategoryId",
                table: "Budget",
                newName: "IX_Budget_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Budgets_ApplicationUserId",
                table: "Budget",
                newName: "IX_Budget_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Budget",
                table: "Budget",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_AspNetUsers_ApplicationUserId",
                table: "Budget",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Budget_Category_CategoryId",
                table: "Budget",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_AspNetUsers_ApplicationUserId",
                table: "Category",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Category_ParentId",
                table: "Category",
                column: "ParentId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_RecordTypes_RecordTypeId",
                table: "Category",
                column: "RecordTypeId",
                principalTable: "RecordTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

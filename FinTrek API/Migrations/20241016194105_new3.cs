using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinTrek_API.Migrations
{
    /// <inheritdoc />
    public partial class new3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "AccountRecords",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    IsTransfer = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRecords", x => new { x.AccountId, x.RecordId });
                    table.ForeignKey(
                        name: "FK_AccountRecords_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRecords_Record_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Record",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CurrencyCodeId", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubscriptionId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "530c7c1a-8287-43a4-940f-d3e23564a58c", 0, "cb473693-804c-4ad1-8a1f-ae8b6db4b6bf", null, "admin@example.com", true, false, null, "Admin", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAECB8skfGnkAOIJMqxXr6efIJNeVL9jsrATtj+fEz51s9AJCRFQPQfSBTAiNXkv8oYA==", null, false, "1a078eb4-d20e-4f61-8a78-7a343699a68c", null, "User", false, "admin@example.com" },
                    { "7e058b85-043e-40ad-a850-867edea5c0e5", 0, "958e3ec1-8e43-4178-a119-2b1076fc8cc7", null, "dev@example.com", true, false, null, "Dev", "DEV@EXAMPLE.COM", "DEV@EXAMPLE.COM", "AQAAAAIAAYagAAAAEEpRey8moJaYVq1SpzxnvXUxcU5Yuhu6FAYJ2dOB930k+Pi9u6k+78FjsuTJxdXnkA==", null, false, "28c0d7fc-1d86-4256-8e5d-2d975dd58051", null, "User", false, "dev@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "530c7c1a-8287-43a4-940f-d3e23564a58c" },
                    { "2", "7e058b85-043e-40ad-a850-867edea5c0e5" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRecords_RecordId",
                table: "AccountRecords",
                column: "RecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRecords");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "530c7c1a-8287-43a4-940f-d3e23564a58c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "7e058b85-043e-40ad-a850-867edea5c0e5" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "530c7c1a-8287-43a4-940f-d3e23564a58c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7e058b85-043e-40ad-a850-867edea5c0e5");

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
        }
    }
}

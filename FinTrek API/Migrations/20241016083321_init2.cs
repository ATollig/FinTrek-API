using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FinTrek_API.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "617fe221-ca87-440a-a63e-564a6171cb6b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "d41fa82b-a295-4639-8aff-50f38899191a" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "617fe221-ca87-440a-a63e-564a6171cb6b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d41fa82b-a295-4639-8aff-50f38899191a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SubscriptionId", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "617fe221-ca87-440a-a63e-564a6171cb6b", 0, "96d270b9-81cc-4203-90fa-dabbadea99f2", "dev@example.com", true, false, null, "Dev", "DEV@EXAMPLE.COM", "DEV@EXAMPLE.COM", "AQAAAAIAAYagAAAAEHGD/yF4GHL7sNwOATGu3MrzPpkBLo5nVJFWEzFqgiRLfUwuf/0GX+1j4XXIZUDQIQ==", null, false, "c037fba5-7818-4a9b-917b-24a92c7f3674", null, "User", false, "dev@example.com" },
                    { "d41fa82b-a295-4639-8aff-50f38899191a", 0, "ad1b6c89-85fb-4075-bc44-148a111c52b4", "admin@example.com", true, false, null, "Admin", "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAECmjO3KVS4GAs331cfwTlSleQDzF8pXN4tr/pAfjlR6EatgH3gyG0lR7yzp+JbJKZA==", null, false, "45224601-fd13-4a3d-b984-3cb268bd1fac", null, "User", false, "admin@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2", "617fe221-ca87-440a-a63e-564a6171cb6b" },
                    { "1", "d41fa82b-a295-4639-8aff-50f38899191a" }
                });
        }
    }
}

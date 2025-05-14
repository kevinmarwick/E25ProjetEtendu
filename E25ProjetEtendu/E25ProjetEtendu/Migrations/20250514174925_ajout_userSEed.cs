using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ajout_userSEed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "user-role-id", null, "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4a0a027-6b97-4a89-80d2-4a91ee6cd3cc", "AQAAAAIAAYagAAAAEMFdkW8nrXpn29J6jQfhb18XBhwq4VLl+7A0pFsObfeuCRxdBKJZWx4Gi1UpZu31eg==", "a872dde9-301a-4bc0-9635-0838052a1507" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32222222-2222-2222-2222-222222222222", 0, 0m, "8afcfeba-3a4e-44a2-9af6-4be937f95597", "user@example.com", true, "Jean", "Utilisateur", false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEI7ac8b/4t+/8/6h73+BBG/9rPCMEffTbgqexr1JsnEjcLG1kgFOqHWTWT+G8ZOJiQ==", null, false, "3fa4f372-919f-490c-9fda-e982dee0acfb", false, "user@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "user-role-id", "32222222-2222-2222-2222-222222222222" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "user-role-id", "32222222-2222-2222-2222-222222222222" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6baed043-e8be-4209-beda-43d0be93dc6b", "AQAAAAIAAYagAAAAEKuA5xTPxeop0Yu5XX9Kq6lCxM95Jvv0KkxOeY4J5s1C3B/KPos6iwCmNcnoSDa46Q==", "c28edb86-1142-4f75-8046-d080dceafec6" });
        }
    }
}

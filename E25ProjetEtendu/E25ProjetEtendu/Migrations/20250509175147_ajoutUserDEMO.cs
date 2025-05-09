using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ajoutUserDEMO : Migration
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
                values: new object[] { "038fc4a1-b2bf-4150-b3a0-30192fb8ae95", "AQAAAAIAAYagAAAAEMsoCMMglO6Dhzu0S+5fSZcmufDVorauHd3rrcDMnFSmRhn/af/ReqSJNVrS1rgd/A==", "fcb5fb94-3229-489b-9afb-8d935d72faa5" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32222222-2222-2222-2222-222222222222", 0, 0m, "34a769e6-78d9-462f-a637-8e7abbe15bda", "user@example.com", true, "Jean", "Utilisateur", false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKe4krH6BnczsgPmimeVIZ18g0v3TimaP4vPOVQBDSD928SqnWEYtEdmNSd7Cj/D+Q==", null, false, "4d333ef7-cc50-453f-afa4-a51cb35be492", false, "user@example.com" });

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
                values: new object[] { "b094cf43-82dc-44eb-96db-020547d3f776", "AQAAAAIAAYagAAAAEK5DBW34bAZxyef9Zv7tUat8nXQ5lymzZMnzheruQPniCzyzJalGAHseSPqD21dYJw==", "68014b63-da07-4401-8380-f99f8c890d76" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ajoutLivreurSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "delivery-role-id", null, "Delivery", "DELIVERY" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f29fa05-98da-406a-93ef-db350e43b2b6", "AQAAAAIAAYagAAAAEFUnOx5ZwMdeyt9Rpe+aAqEy2oY1kDsWBramMRvFxlkNacEWAp32m/nRR/eSziqyTA==", "e3859cd6-e569-4ddc-8c88-6b6407813817" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30352ad9-d717-49af-b661-ce81dae361c5", "AQAAAAIAAYagAAAAEOVP+EiXgEdKuHRkbywz+aTRARA7j2p9Rxn/hv/HhlQ5uGb/e3sZSHouJHvrXVJz+A==", "d335295a-a925-4830-9bd6-360df2a3fb76" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "42222222-2222-2222-2222-222222222222", 0, 0m, "79bd73bc-50e1-49a7-bb93-e2e3a84bb785", "livreur@example.com", true, "Livreur", "Livreur", false, null, "LIVREUR@EXAMPLE.COM", "LIVREUR@EXAMPLE.COM", "AQAAAAIAAYagAAAAEGnzaxPVV/kYhJnIKD2xtdTFXNBrJYNSWFOmebqLsto9fRp9iett3+c3fQOzAyWYew==", null, false, "02fe671d-0c29-4c2a-9216-c9ffb95d506f", false, "livreur@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "delivery-role-id", "42222222-2222-2222-2222-222222222222" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "delivery-role-id", "42222222-2222-2222-2222-222222222222" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "delivery-role-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e3a5714-3bb7-441b-8578-3d851e1f89ce", "AQAAAAIAAYagAAAAEI6dvTSVSeHY6+Vo6N6i4QNrCezyv/pmTu77+6ibvTW0LQovvXOqHzl4OOXamiZmIg==", "c8cb5f23-703a-4ea4-b4cc-d69f492c7d1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1560494a-3262-4f36-9306-a573f69d6650", "AQAAAAIAAYagAAAAEC0yYRVPtUX8SpeQuxUb4rwXQRYXtGrVIK40fYydnu5UjSGWcK9uHpEhGtvEW3AVzQ==", "076abbc1-1117-47aa-9a83-272d1a055e54" });
        }
    }
}

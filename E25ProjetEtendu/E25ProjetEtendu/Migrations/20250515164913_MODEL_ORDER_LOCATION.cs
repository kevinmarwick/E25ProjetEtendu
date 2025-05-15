using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class MODEL_ORDER_LOCATION : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4a0a027-6b97-4a89-80d2-4a91ee6cd3cc", "AQAAAAIAAYagAAAAEMFdkW8nrXpn29J6jQfhb18XBhwq4VLl+7A0pFsObfeuCRxdBKJZWx4Gi1UpZu31eg==", "a872dde9-301a-4bc0-9635-0838052a1507" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8afcfeba-3a4e-44a2-9af6-4be937f95597", "AQAAAAIAAYagAAAAEI7ac8b/4t+/8/6h73+BBG/9rPCMEffTbgqexr1JsnEjcLG1kgFOqHWTWT+G8ZOJiQ==", "3fa4f372-919f-490c-9fda-e982dee0acfb" });
        }
    }
}

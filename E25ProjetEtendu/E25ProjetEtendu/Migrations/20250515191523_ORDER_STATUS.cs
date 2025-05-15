using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ORDER_STATUS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9df00bb-867f-438c-82c7-30f0907a75fa", "AQAAAAIAAYagAAAAEDIiggfuxJEEDPQdYljCQkHLJjqmpOlNL7pveaaC07ghV9xeySPEw9CSDqMMGfRn2g==", "5b9cccec-160e-47ce-a35c-6f1a21f49772" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5523e415-0458-433a-b51d-a259b32ebd0c", "AQAAAAIAAYagAAAAEBVolwg78V6w6pRw82/JU15zllFk5nXwSkiJfXoTLg3Y+jU//HwJCx3h6XV8W97LlQ==", "670bfd08-c9ed-47ab-a374-a593c32f39d8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

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

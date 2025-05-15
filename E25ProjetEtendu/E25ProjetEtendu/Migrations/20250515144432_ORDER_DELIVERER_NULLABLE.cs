using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ORDER_DELIVERER_NULLABLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DelivererId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1756e8bd-acc2-4108-a311-109fc9f45b36", "AQAAAAIAAYagAAAAEBcvpC7ZGBb/w2WG/z4HquPpRlO9n96iue95ghkkxe79k1msFtqbMLHy0k+4oacSdw==", "a18a8f47-7b8c-4af7-ad06-b2c1908fbf6f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DelivererId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6baed043-e8be-4209-beda-43d0be93dc6b", "AQAAAAIAAYagAAAAEKuA5xTPxeop0Yu5XX9Kq6lCxM95Jvv0KkxOeY4J5s1C3B/KPos6iwCmNcnoSDa46Q==", "c28edb86-1142-4f75-8046-d080dceafec6" });
        }
    }
}

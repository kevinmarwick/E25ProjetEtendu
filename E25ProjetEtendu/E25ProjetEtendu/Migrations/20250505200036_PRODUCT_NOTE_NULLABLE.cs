using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class PRODUCT_NOTE_NULLABLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Note",
                table: "produits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "201c30b8-53a3-460d-8f23-a65c1d63f1e8", "AQAAAAIAAYagAAAAEAWzwizuk96riR16iNbPvI/NYG0KCtDPML1GibAV2Zz6fY2nwVMiFR7vpbpPQD1x7Q==", "9b5faa6f-b44f-4932-8dd1-f7f478e07680" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Note",
                table: "produits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d13e8fd6-51db-401f-9439-05ae61198044", "AQAAAAIAAYagAAAAEByPItlr1c9wZwzXpj7+dig6l5OLUvgZ7rNAjXG0QP7Ljy/ZSPpk+0n3oUaAjBrapw==", "988a995d-ac18-4234-885e-5e98e3929d79" });
        }
    }
}

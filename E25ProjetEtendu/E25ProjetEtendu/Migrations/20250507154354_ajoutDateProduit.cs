using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ajoutDateProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAjout",
                table: "produits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04e70b73-7118-4885-8685-b8d3f9d6dcdb", "AQAAAAIAAYagAAAAEGqfhiNjWlbuHkoWzKP3MqJMqAB0lgaQChCUnPXNscRD8d4UMUS5Ibcs1VU0LT8ntQ==", "b7be0fac-e3e0-4c01-a6d8-159ce8900e56" });

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 1,
                column: "DateAjout",
                value: new DateTime(2025, 3, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 2,
                column: "DateAjout",
                value: new DateTime(2025, 3, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 3,
                column: "DateAjout",
                value: new DateTime(2025, 3, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 4,
                column: "DateAjout",
                value: new DateTime(2025, 3, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 5,
                column: "DateAjout",
                value: new DateTime(2025, 3, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 6,
                column: "DateAjout",
                value: new DateTime(2025, 3, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4829));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 7,
                column: "DateAjout",
                value: new DateTime(2025, 3, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 8,
                column: "DateAjout",
                value: new DateTime(2025, 3, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4836));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 9,
                column: "DateAjout",
                value: new DateTime(2025, 5, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4839));

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 10,
                column: "DateAjout",
                value: new DateTime(2025, 5, 7, 11, 43, 52, 910, DateTimeKind.Local).AddTicks(4843));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAjout",
                table: "produits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "201c30b8-53a3-460d-8f23-a65c1d63f1e8", "AQAAAAIAAYagAAAAEAWzwizuk96riR16iNbPvI/NYG0KCtDPML1GibAV2Zz6fY2nwVMiFR7vpbpPQD1x7Q==", "9b5faa6f-b44f-4932-8dd1-f7f478e07680" });
        }
    }
}

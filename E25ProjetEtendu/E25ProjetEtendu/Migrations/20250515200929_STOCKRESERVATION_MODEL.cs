using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class STOCKRESERVATION_MODEL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReservedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockReservations_produits_ProductId",
                        column: x => x.ProductId,
                        principalTable: "produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3ea94838-5812-4862-8869-11c49712a590", "AQAAAAIAAYagAAAAEE122mQKUoWi4bZxNQ+l3z8CuTj5IwUVRYsjahWgKz9lQsIwrFOaygLLX/14l0RVXw==", "2b1427f1-137d-42f1-8eb8-780a7005778c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee6bace4-752f-410b-a14c-faf2a048c370", "AQAAAAIAAYagAAAAEPYD8zej/o6UwmR/V07gXQoZaqIq2mNY54zmxEiXTaYEdCvtF7CnloJz8kkTgnuFxA==", "1a28ff13-9527-40f2-8398-45b92974f21e" });

            migrationBuilder.CreateIndex(
                name: "IX_StockReservations_ProductId",
                table: "StockReservations",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockReservations");

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

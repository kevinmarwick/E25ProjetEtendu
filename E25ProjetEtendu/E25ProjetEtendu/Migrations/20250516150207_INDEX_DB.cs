using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class INDEX_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a8d293b-7fbe-47ca-b932-8cc445150f20", "AQAAAAIAAYagAAAAEPLItxPoHIgC2rgIG0mxjrnT49RqpRLRRlF//saP8n6N967jdxav6i9bE2S2cgwhFA==", "427ceeed-97cb-4169-b089-b7f5ba31ba76" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "458b8dc7-2959-4c43-89a5-1a77565baf3b", "AQAAAAIAAYagAAAAEF7MvVI9VnLyXgs7ZzyBxAkbxRBy/bOg65mBEDHoqfcoZ1/74PmZw0fSQ3DeobkScA==", "ec859184-3a6a-423f-a4de-78c1cf946d91" });

            migrationBuilder.CreateIndex(
                name: "IX_StockReservations_ReservedAt",
                table: "StockReservations",
                column: "ReservedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StockReservations_ReservedAt",
                table: "StockReservations");

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
        }
    }
}

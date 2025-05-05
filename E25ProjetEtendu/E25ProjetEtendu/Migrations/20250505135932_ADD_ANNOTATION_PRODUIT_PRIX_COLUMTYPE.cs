using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ADD_ANNOTATION_PRODUIT_PRIX_COLUMTYPE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "678bab9d-45ac-4207-9f7d-eaa04f4c432b", "AQAAAAIAAYagAAAAECbReskhCdED4vO0EPDothqCei5wanygUXHGBAws8T14dDktKJZqdQx4o07ptUFobw==", "e338b144-e11b-412d-824d-075c8c0f51fa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49565136-ba29-4f10-8e54-e8f392365cc8", "AQAAAAIAAYagAAAAEEqXJvU9JJSQdEKU0XV810x96VEGsG4aYsQO920FBVtI/lfhXlKPgIQ4fKZjAXrMKQ==", "e074b430-5e1b-4e41-b2f4-fba1846b122d" });
        }
    }
}

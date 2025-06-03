using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ajoutCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "produits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a3e41b2-f732-4a98-9dd7-dd2f2f0a091a", "AQAAAAIAAYagAAAAEHKCx5HWAEWwg3cP9G4HE7QOOgpEwUpOaw1+v+yHfWso20qapnZsbDcOIMUdMh461g==", "782a5e22-0bab-47a1-a75a-80a3a053d7f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "05c77a90-ba57-4835-8216-f060953f0856", "AQAAAAIAAYagAAAAEOsTNN4pJB5V4zkZjZi8N7a/DjGIXqEZd4a0IhnMBjtJaUDExISdhPkCTfyHWrzeLw==", "f26ae3dc-7384-43e0-9532-19c5a566e9ca" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d51abf9b-1c1f-447c-9b3d-7bc95d0e5c06", "AQAAAAIAAYagAAAAEFnfwRKN5WmUGcVZNOR8TIda6VcDrDaPr5N43fuJx828RREopucjM4AG81GGDWvfmw==", "ebaa8602-99ab-4d5f-945e-a035f1719c6e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe0285c6-80fc-446c-9fe5-51a5ebf475ae", "AQAAAAIAAYagAAAAEOsTNN4pJB5V4zkZjZi8N7a/DjGIXqEZd4a0IhnMBjtJaUDExISdhPkCTfyHWrzeLw==", "113323db-b672-47ef-b883-d17d1fc080d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c27fbf76-45c7-4237-8b0f-12dff83b14be", "AQAAAAIAAYagAAAAEOsTNN4pJB5V4zkZjZi8N7a/DjGIXqEZd4a0IhnMBjtJaUDExISdhPkCTfyHWrzeLw==", "b5ff90e4-b5b0-4e69-970c-368c72f37665" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f884eda-957a-452e-b337-6dc073c85363", "AQAAAAIAAYagAAAAEOsTNN4pJB5V4zkZjZi8N7a/DjGIXqEZd4a0IhnMBjtJaUDExISdhPkCTfyHWrzeLw==", "848fd9f5-ff4b-4bb7-88ec-fba345ac66a2" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Aliment" },
                    { 2, "Breuvage" },
                    { 3, "Hygiène" },
                    { 4, "Matériel scolaire" }
                });

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 1,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 2,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 3,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 4,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 5,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 6,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 7,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 8,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 9,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 10,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 11,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 12,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 13,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 14,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 15,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 16,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 17,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 18,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 19,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 20,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 21,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 22,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 23,
                column: "CategoryId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 24,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 25,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 26,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 27,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 28,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 29,
                column: "CategoryId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 30,
                column: "CategoryId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 31,
                column: "CategoryId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_produits_CategoryId",
                table: "produits",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_produits_Categories_CategoryId",
                table: "produits",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_produits_Categories_CategoryId",
                table: "produits");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_produits_CategoryId",
                table: "produits");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "produits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c7003f2-e816-473a-bf93-2b7df3fe175d", "AQAAAAIAAYagAAAAEDQW32Li/+QK/sYpUVyryJ0eOAay4enCyb6jRqUPxxNLSROvIpXo71TirdayNedlew==", "bb38db1d-1d66-4328-8518-3491740c4635" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0ee7214-59fd-4d3a-b6f5-80f06f7a765c", "AQAAAAIAAYagAAAAECGnax8seY7VQjFMq8Dm3dy76Ktlio8/zPgpV8zn0mhX1TrLwN40PbvDVKibLGrwFw==", "e0e40b9d-1dd9-48e6-a12f-60c98f165edd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9883216e-2d54-4ad2-a444-c0c5babbd9cb", "AQAAAAIAAYagAAAAEIBfmkCa1sHY44t2hBZ8p2vNlpbbfhY5uPqElUemoJc+QpUd01l4SYfutlaT96o6IQ==", "5a28aa8c-8638-4f7b-951e-203ad0e56e60" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a536ecd-b4cb-4e1d-8ca8-58ac4f763018", "AQAAAAIAAYagAAAAECGnax8seY7VQjFMq8Dm3dy76Ktlio8/zPgpV8zn0mhX1TrLwN40PbvDVKibLGrwFw==", "31fe873d-0ddc-44ab-9a43-4b483ed8f2f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcaecddb-6417-426c-b16a-2a218fb468af", "AQAAAAIAAYagAAAAECGnax8seY7VQjFMq8Dm3dy76Ktlio8/zPgpV8zn0mhX1TrLwN40PbvDVKibLGrwFw==", "b038333a-8bf1-4f2f-8656-106d655420be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d29cd8cd-2461-4559-b063-ddaa55cbcf2d", "AQAAAAIAAYagAAAAECGnax8seY7VQjFMq8Dm3dy76Ktlio8/zPgpV8zn0mhX1TrLwN40PbvDVKibLGrwFw==", "ca257ddd-172f-42ff-ada8-33758be592e8" });
        }
    }
}

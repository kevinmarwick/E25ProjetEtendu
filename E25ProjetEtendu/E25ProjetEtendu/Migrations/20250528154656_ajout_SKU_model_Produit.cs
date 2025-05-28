using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ajout_SKU_model_Produit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SKU",
                table: "produits",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3c8965ab-fac0-4dfc-a4a3-697f4edef7f1", "AQAAAAIAAYagAAAAEFIcHVXNTbYXzRyozW0t8BMIWdp57+qBjOQwbQ4KXwXstzOyx0brTEarKLe1aTCXxA==", "6a08cdf2-a04d-47dd-9546-82bfd3851e58" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "259d7dee-7378-4dec-99e8-5cafe25c9cf9", "AQAAAAIAAYagAAAAENkNEomLSCXNt3OzEm/Uf4ql4XcbVQSq3RV5Kt3khMueF6/wiYgElfraUqzZPKLUYQ==", "48f1e37e-48f5-476a-8028-193baf79f2a5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a14344ab-348d-4c75-993a-69498d9996fb", "AQAAAAIAAYagAAAAEHXu2+m9F3/oiG+JteyLUZt3W6drSNqJig16cPeR9gsd8UfKQo73QMj5ajjUuCreBw==", "5c88872c-9286-4ac6-a26a-53529e0b2f6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64682d16-a96e-4269-94de-9d4adea4a6c3", "AQAAAAIAAYagAAAAENkNEomLSCXNt3OzEm/Uf4ql4XcbVQSq3RV5Kt3khMueF6/wiYgElfraUqzZPKLUYQ==", "3e66dcae-92ce-4704-bb72-5d4820464d5d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f891d0d6-0f97-4c3d-82be-40467515e06a", "AQAAAAIAAYagAAAAENkNEomLSCXNt3OzEm/Uf4ql4XcbVQSq3RV5Kt3khMueF6/wiYgElfraUqzZPKLUYQ==", "ff99eedc-ac4e-4d2e-b79f-653b6626a2ae" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "971f78a4-34e8-4b6a-9330-870bbea90de5", "AQAAAAIAAYagAAAAENkNEomLSCXNt3OzEm/Uf4ql4XcbVQSq3RV5Kt3khMueF6/wiYgElfraUqzZPKLUYQ==", "d430fa3f-ab16-4010-8e69-c6e7a76bab1c" });

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 1,
                column: "SKU",
                value: "100001");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 2,
                column: "SKU",
                value: "100002");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 3,
                column: "SKU",
                value: "100003");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 4,
                column: "SKU",
                value: "100004");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 5,
                column: "SKU",
                value: "100005");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 6,
                column: "SKU",
                value: "100006");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 7,
                column: "SKU",
                value: "100007");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 8,
                column: "SKU",
                value: "100008");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 9,
                column: "SKU",
                value: "100009");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 10,
                column: "SKU",
                value: "100010");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 11,
                column: "SKU",
                value: "100011");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 12,
                column: "SKU",
                value: "100012");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 13,
                column: "SKU",
                value: "100013");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 14,
                column: "SKU",
                value: "100014");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 15,
                column: "SKU",
                value: "100015");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 16,
                column: "SKU",
                value: "100016");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 17,
                column: "SKU",
                value: "100017");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 18,
                column: "SKU",
                value: "100018");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 19,
                column: "SKU",
                value: "100019");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 20,
                column: "SKU",
                value: "100020");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 21,
                column: "SKU",
                value: "100021");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 22,
                column: "SKU",
                value: "100022");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 23,
                column: "SKU",
                value: "100023");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 24,
                column: "SKU",
                value: "100024");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 25,
                column: "SKU",
                value: "100025");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 26,
                column: "SKU",
                value: "100026");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 27,
                column: "SKU",
                value: "100027");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 28,
                column: "SKU",
                value: "100028");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 29,
                column: "SKU",
                value: "100029");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 30,
                column: "SKU",
                value: "100030");

            migrationBuilder.UpdateData(
                table: "produits",
                keyColumn: "ProduitId",
                keyValue: 31,
                column: "SKU",
                value: "100031");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKU",
                table: "produits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68379c8b-937d-4d04-a8cd-22c0485049a7", "AQAAAAIAAYagAAAAEH+KkEsJXKFlUc0d8BmOBwtOAWUNUqTFZLKOI4MrzMn9H3ES93ZK+UBqHFicaLQw0w==", "007de394-c018-4b23-a9c1-13c13f68a26c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ec1c601-ca83-4c31-b712-022da51c636a", "AQAAAAIAAYagAAAAENY5orQqloBPCahhFEkHo5+6GlbeWlGWtFnJOhjnOLLsWIdRKqji/legoOG1xeLoLw==", "af0b5d2a-175f-46be-afe6-f86140c74d55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42222222-2222-2222-2222-222222222222",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22fa3659-ab8e-4ec5-93ab-479384e4f7c7", "AQAAAAIAAYagAAAAELTEo7ILI492YNbHiEZGKfovGlH2a1Bz+T29ZZ+Wepmxm2MQRnXsix08ThqkDDpmOQ==", "a38a5274-4e50-4725-9fca-e388a650ef19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43333333-3333-3333-3333-333333333333",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "13046776-206f-445b-951b-f9fce727b0bd", "AQAAAAIAAYagAAAAENY5orQqloBPCahhFEkHo5+6GlbeWlGWtFnJOhjnOLLsWIdRKqji/legoOG1xeLoLw==", "c0cf8a63-5bf1-482b-88cd-6831c1396aee" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "54444444-4444-4444-4444-444444444444",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5864331-788e-40c4-8e92-0a534778500c", "AQAAAAIAAYagAAAAENY5orQqloBPCahhFEkHo5+6GlbeWlGWtFnJOhjnOLLsWIdRKqji/legoOG1xeLoLw==", "ec4a4565-8c63-42a0-9bba-3ace42ee077f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65555555-5555-5555-5555-555555555555",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b5f55ca-7bf4-4369-a2b8-963d8032e757", "AQAAAAIAAYagAAAAENY5orQqloBPCahhFEkHo5+6GlbeWlGWtFnJOhjnOLLsWIdRKqji/legoOG1xeLoLw==", "468e709d-df9d-48c3-9bdb-c6c65f969bc1" });
        }
    }
}

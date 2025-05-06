using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produits",
                columns: table => new
                {
                    ProduitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EstActif = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false),
                    ValeurNutritive = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produits", x => x.ProduitId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "admin-role-id", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "21111111-1111-1111-1111-111111111111", 0, 0m, "a9811c84-4783-44cc-83fb-9e5011e76bfc", "admin@example.com", true, "Admin", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKmnJPqLYPJ4VV239DEmpZh1/a1xbXy0uC3EViQ2cYJeLLSll+Gh3WjxLJn4k8O0Pw==", null, false, "fd433c0f-2a1e-42cd-a04b-a13102764f1f", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "produits",
                columns: new[] { "ProduitId", "EstActif", "Image", "Nom", "Note", "Prix", "Qty", "ValeurNutritive" },
                values: new object[,]
                {
                    { 1, true, "redbull.png", "Red Bull", 4, 3m, 120, "Calories: 110, Sucres: 27g, Caféine: 80mg, Glucides: 28g, Protéines: 1g" },
                    { 2, true, "pogo.jpg", "Pogo", 3, 2m, 200, "Calories: 190, Lipides: 9g, Glucides: 20g, Protéines: 6g, Sodium: 500mg" },
                    { 3, true, "eau.jpg", "Bouteille d'eau", 5, 1m, 300, "Calories: 0, Lipides: 0g, Sucres: 0g, Sodium: 0mg" },
                    { 4, true, "chips.jpg", "Chips Lay’s", 4, 2m, 100, "Calories: 160, Lipides: 10g, Glucides: 15g, Sucres: 1g, Sodium: 170mg" },
                    { 5, true, "nutella.jpg", "Nutella", 5, 5m, 80, "Calories: 200, Lipides: 11g, Glucides: 22g, Sucres: 21g, Protéines: 2g" },
                    { 6, true, "activia.jpg", "Yogourt Activia", 4, 3m, 150, "Calories: 100, Lipides: 2g, Glucides: 15g, Sucres: 12g, Protéines: 5g" },
                    { 7, true, "pizza.jpg", "Pizza congelée", 4, 6m, 60, "Calories: 350, Lipides: 15g, Glucides: 40g, Sucres: 5g, Protéines: 12g" },
                    { 8, true, "granola.jpg", "Barre de granola", 4, 2m, 180, "Calories: 190, Lipides: 7g, Glucides: 29g, Sucres: 11g, Protéines: 4g" },
                    { 9, true, "coca.jpg", "Coca-Cola", 3, 2m, 220, "Calories: 140, Sucres: 39g, Glucides: 39g, Sodium: 45mg" },
                    { 10, true, "sandwich.jpg", "Sandwich jambon-fromage", 4, 4m, 75, "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg" },
                    { 11, true, "starbucks.jpg", "Café Starbucks", 4, 4m, 90, "Calories: 150, Sucres: 20g, Caféine: 95mg" },
                    { 12, true, "axe.jpg", "Déodorant Axe", 5, 6m, 50, "Sans calories" },
                    { 13, true, "headshoulders.jpg", "Shampooing Head & Shoulders", 4, 7m, 60, "Sans calories" },
                    { 14, true, "benjerry.jpg", "Crème glacée Ben & Jerry's", 5, 8m, 40, "Calories: 270, Lipides: 14g, Sucres: 26g" },
                    { 15, true, "pain.jpg", "Pain tranché", 3, 3m, 120, "Calories: 80, Glucides: 15g, Protéines: 3g" },
                    { 16, true, "cheddar.jpg", "Fromage cheddar", 4, 5m, 100, "Calories: 110, Lipides: 9g, Protéines: 7g" },
                    { 17, true, "yaourt.jpg", "Yaourt grec", 4, 4m, 130, "Calories: 120, Protéines: 10g, Sucres: 8g" },
                    { 18, true, "ritz.jpg", "Crackers Ritz", 3, 3m, 80, "Calories: 160, Lipides: 8g, Glucides: 20g" },
                    { 19, true, "soupe.jpg", "Soupe Campbell", 4, 2m, 70, "Calories: 90, Sodium: 480mg" },
                    { 20, true, "tropicana.jpg", "Jus d'orange Tropicana", 4, 3m, 150, "Calories: 110, Sucres: 23g" },
                    { 21, true, "colgate.jpg", "Brosse à dents Colgate", 4, 2m, 200, "Sans calories" },
                    { 22, true, "sensodyne.jpg", "Dentifrice Sensodyne", 5, 5m, 150, "Sans calories" },
                    { 23, true, "dove.jpg", "Savon Dove", 4, 2m, 180, "Sans calories" },
                    { 24, true, "gatorade.jpg", "Boisson Gatorade", 4, 3m, 110, "Calories: 80, Sucres: 21g" },
                    { 25, true, "kinder.jpg", "Chocolat Kinder", 5, 2m, 100, "Calories: 120, Sucres: 12g" },
                    { 26, true, "cheerios.jpg", "Céréales Cheerios", 4, 4m, 90, "Calories: 110, Glucides: 20g, Protéines: 3g" },
                    { 27, true, "oreo.jpg", "Biscuit Oreo", 4, 3m, 130, "Calories: 160, Sucres: 14g" },
                    { 28, true, "beurre.jpg", "Beurre d'arachide", 4, 5m, 70, "Calories: 190, Lipides: 16g, Protéines: 7g" },
                    { 29, true, "perrier.jpg", "Eau gazeuse Perrier", 4, 2m, 200, "Calories: 0" },
                    { 30, true, "muffin.jpg", "Muffin aux bleuets", 5, 3m, 60, "Calories: 380, Lipides: 16g, Sucres: 28g" },
                    { 31, true, "Aid.jpg", "BandAid", 5, 3m, 0, "Calories: 0" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin-role-id", "21111111-1111-1111-1111-111111111111" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "produits");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

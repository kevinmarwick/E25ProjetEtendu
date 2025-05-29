using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class MIG_RESET : Migration
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
                    InventoryQuantity = table.Column<int>(type: "int", nullable: false),
                    Prix = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EstActif = table.Column<bool>(type: "bit", nullable: false),
                    Note = table.Column<int>(type: "int", nullable: true),
                    ValeurNutritive = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DelivererId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_produits_ProductId",
                        column: x => x.ProductId,
                        principalTable: "produits",
                        principalColumn: "ProduitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin-role-id", null, "Admin", "ADMIN" },
                    { "deliverystation-role-id", null, "DeliveryStation", "DELIVERYSTATION" },
                    { "livreur-role-id", null, "Livreur", "LIVREUR" },
                    { "user-role-id", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Balance", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "21111111-1111-1111-1111-111111111111", 0, 0m, "c10d0088-c7f3-4fd6-b3c7-f7f709cffcf2", "admin@example.com", true, "Admin", "Admin", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOIdkYxq+1XB2VFMqMyyKjudbkBCSULAdVkf/e6DHGrYieFD0EOd9uk43zHId35VrQ==", null, false, "9b108876-a962-4c77-bef2-87a3fd5818d9", false, "admin@example.com" },
                    { "32222222-2222-2222-2222-222222222222", 0, 0m, "5b8d1b86-c210-4b12-a64b-36c16104c9f4", "user@example.com", true, "Jean", "Utilisateur", false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", null, false, "c6f61dda-d64f-4ebb-81b1-6da97ed91aa6", false, "jean@example.com" },
                    { "42222222-2222-2222-2222-222222222222", 0, 0m, "457d3ca4-4781-47c0-bcdf-fd847f752b71", "livreur@example.com", true, "Livreur", "Livreur", false, null, "LIVREUR@EXAMPLE.COM", "LIVREUR@EXAMPLE.COM", "AQAAAAIAAYagAAAAEL6eT59Yc/Lxqo4O6f/6vsDsIt8TU38t+KFFxcJtIHXrZHwzJCYaRGE9+AxIeWP/VA==", null, false, "c0b072a8-b781-4fcc-8fd8-054a4b53a820", false, "livreur@example.com" },
                    { "43333333-3333-3333-3333-333333333333", 0, 0m, "cbb0cd42-3660-4437-add6-56da75eb6e5e", "jacob@example.com", true, "Jacob", "Utilisateur", false, null, "JACOB@EXAMPLE.COM", "JACOB@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", null, false, "9b01a83f-fed9-4d6d-9982-aefb6fbdeb56", false, "jacob@example.com" },
                    { "54444444-4444-4444-4444-444444444444", 0, 0m, "fdf9479c-da23-4c2a-856c-e248226f693f", "maxime@example.com", true, "Maxime", "Utilisateur", false, null, "MAXIME@EXAMPLE.COM", "MAXIME@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", null, false, "49c5985e-050f-4298-8043-3f33738dda96", false, "maxime@example.com" },
                    { "65555555-5555-5555-5555-555555555555", 0, 0m, "2720d98e-83cd-453c-bf05-df164328856a", "nicolas@example.com", true, "Nicolas", "Utilisateur", false, null, "NICOLAS@EXAMPLE.COM", "NICOLAS@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAUOhYozFE9yvlCTyCV8vzWacV4la1j6+K05POn+6rg3LLpw8a//U8JgajNr/VoCpA==", null, false, "d327e4ca-be80-433e-b44b-564fb13d7c31", false, "nicolas@example.com" }
                });

            migrationBuilder.InsertData(
                table: "produits",
                columns: new[] { "ProduitId", "EstActif", "Image", "InventoryQuantity", "Nom", "Note", "Prix", "SKU", "ValeurNutritive" },
                values: new object[,]
                {
                    { 1, true, "redbull.png", 120, "Red Bull", 4, 3m, "100001", "Calories: 110, Sucres: 27g, Caféine: 80mg, Glucides: 28g, Protéines: 1g" },
                    { 2, true, "pogo.jpg", 200, "Pogo", 3, 2m, "100002", "Calories: 190, Lipides: 9g, Glucides: 20g, Protéines: 6g, Sodium: 500mg" },
                    { 3, true, "eau.jpg", 300, "Bouteille d'eau", 5, 1m, "100003", "Calories: 0, Lipides: 0g, Sucres: 0g, Sodium: 0mg" },
                    { 4, true, "chips.jpg", 100, "Chips Lay’s", 4, 2m, "100004", "Calories: 160, Lipides: 10g, Glucides: 15g, Sucres: 1g, Sodium: 170mg" },
                    { 5, true, "nutella.jpg", 80, "Nutella", 5, 5m, "100005", "Calories: 200, Lipides: 11g, Glucides: 22g, Sucres: 21g, Protéines: 2g" },
                    { 6, true, "activia.jpg", 150, "Yogourt Activia", 4, 3m, "100006", "Calories: 100, Lipides: 2g, Glucides: 15g, Sucres: 12g, Protéines: 5g" },
                    { 7, true, "pizza.jpg", 60, "Pizza congelée", 4, 6m, "100007", "Calories: 350, Lipides: 15g, Glucides: 40g, Sucres: 5g, Protéines: 12g" },
                    { 8, true, "granola.jpg", 180, "Barre de granola", 4, 2m, "100008", "Calories: 190, Lipides: 7g, Glucides: 29g, Sucres: 11g, Protéines: 4g" },
                    { 9, true, "coca.jpg", 220, "Coca-Cola", 3, 2m, "100009", "Calories: 140, Sucres: 39g, Glucides: 39g, Sodium: 45mg" },
                    { 10, true, "sandwich.jpg", 75, "Sandwich jambon-fromage", 4, 4m, "100010", "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg" },
                    { 11, true, "starbucks.jpg", 90, "Café Starbucks", 4, 4m, "100011", "Calories: 150, Sucres: 20g, Caféine: 95mg" },
                    { 12, true, "axe.jpg", 50, "Déodorant Axe", 5, 6m, "100012", "Sans calories" },
                    { 13, true, "headshoulders.jpg", 60, "Shampooing Head & Shoulders", 4, 7m, "100013", "Sans calories" },
                    { 14, true, "benjerry.jpg", 40, "Crème glacée Ben & Jerry's", 5, 8m, "100014", "Calories: 270, Lipides: 14g, Sucres: 26g" },
                    { 15, true, "pain.jpg", 120, "Pain tranché", 3, 3m, "100015", "Calories: 80, Glucides: 15g, Protéines: 3g" },
                    { 16, true, "cheddar.jpg", 100, "Fromage cheddar", 4, 5m, "100016", "Calories: 110, Lipides: 9g, Protéines: 7g" },
                    { 17, true, "yaourt.jpg", 130, "Yaourt grec", 4, 4m, "100017", "Calories: 120, Protéines: 10g, Sucres: 8g" },
                    { 18, true, "ritz.jpg", 80, "Crackers Ritz", 3, 3m, "100018", "Calories: 160, Lipides: 8g, Glucides: 20g" },
                    { 19, true, "soupe.jpg", 70, "Soupe Campbell", 4, 2m, "100019", "Calories: 90, Sodium: 480mg" },
                    { 20, true, "tropicana.jpg", 150, "Jus d'orange Tropicana", 4, 3m, "100020", "Calories: 110, Sucres: 23g" },
                    { 21, true, "colgate.jpg", 200, "Brosse à dents Colgate", 4, 2m, "100021", "Sans calories" },
                    { 22, true, "sensodyne.jpg", 150, "Dentifrice Sensodyne", 5, 5m, "100022", "Sans calories" },
                    { 23, true, "dove.jpg", 180, "Savon Dove", 4, 2m, "100023", "Sans calories" },
                    { 24, true, "gatorade.jpg", 110, "Boisson Gatorade", 4, 3m, "100024", "Calories: 80, Sucres: 21g" },
                    { 25, true, "kinder.jpg", 100, "Chocolat Kinder", 5, 2m, "100025", "Calories: 120, Sucres: 12g" },
                    { 26, true, "cheerios.jpg", 90, "Céréales Cheerios", 4, 4m, "100026", "Calories: 110, Glucides: 20g, Protéines: 3g" },
                    { 27, true, "oreo.jpg", 130, "Biscuit Oreo", 4, 3m, "100027", "Calories: 160, Sucres: 14g" },
                    { 28, true, "beurre.jpg", 70, "Beurre d'arachide", 4, 5m, "100028", "Calories: 190, Lipides: 16g, Protéines: 7g" },
                    { 29, true, "perrier.jpg", 200, "Eau gazeuse Perrier", 4, 2m, "100029", "Calories: 0" },
                    { 30, true, "muffin.jpg", 60, "Muffin aux bleuets", 5, 3m, "100030", "Calories: 380, Lipides: 16g, Sucres: 28g" },
                    { 31, true, "Aid.jpg", 0, "BandAid", 5, 3m, "100031", "Calories: 0" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin-role-id", "21111111-1111-1111-1111-111111111111" },
                    { "user-role-id", "32222222-2222-2222-2222-222222222222" },
                    { "deliverystation-role-id", "42222222-2222-2222-2222-222222222222" },
                    { "livreur-role-id", "43333333-3333-3333-3333-333333333333" },
                    { "user-role-id", "43333333-3333-3333-3333-333333333333" },
                    { "user-role-id", "54444444-4444-4444-4444-444444444444" },
                    { "user-role-id", "65555555-5555-5555-5555-555555555555" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "BuyerId", "DelivererId", "Location", "OrderDate", "Status", "TotalPrice" },
                values: new object[,]
                {
                    { 2001, "32222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "D-0001", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6.00m },
                    { 2002, "32222222-2222-2222-2222-222222222222", "43333333-3333-3333-3333-333333333333", "D-0002", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4.00m },
                    { 2003, "54444444-4444-4444-4444-444444444444", "43333333-3333-3333-3333-333333333333", "D-0003", new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5.00m },
                    { 2004, "54444444-4444-4444-4444-444444444444", "43333333-3333-3333-3333-333333333333", "D-0004", new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2.00m },
                    { 2005, "65555555-5555-5555-5555-555555555555", "43333333-3333-3333-3333-333333333333", "D-0005", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2.00m },
                    { 2006, "65555555-5555-5555-5555-555555555555", "43333333-3333-3333-3333-333333333333", "D-0006", new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3.00m },
                    { 2007, "32222222-2222-2222-2222-222222222222", null, "D-0007", new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3.00m },
                    { 2008, "54444444-4444-4444-4444-444444444444", null, "D-0008", new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4.00m },
                    { 2009, "65555555-5555-5555-5555-555555555555", null, "D-0009", new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 2.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 2001, 1, 2, 3.00m },
                    { 2, 2002, 2, 2, 2.00m },
                    { 3, 2003, 5, 1, 5.00m },
                    { 4, 2004, 8, 1, 2.00m },
                    { 5, 2005, 9, 1, 2.00m },
                    { 6, 2006, 6, 1, 3.00m },
                    { 7, 2007, 9, 1, 3.00m },
                    { 8, 2008, 5, 1, 4.00m },
                    { 9, 2009, 2, 1, 2.00m }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerId",
                table: "Orders",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DelivererId",
                table: "Orders",
                column: "DelivererId");

            migrationBuilder.CreateIndex(
                name: "IX_StockReservations_ProductId",
                table: "StockReservations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockReservations_ReservedAt",
                table: "StockReservations",
                column: "ReservedAt");
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
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "StockReservations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "produits");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

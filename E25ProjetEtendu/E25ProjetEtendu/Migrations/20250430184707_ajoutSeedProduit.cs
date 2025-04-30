using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class ajoutSeedProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 10, true, "sandwich.jpg", "Sandwich jambon-fromage", 4, 4m, 75, "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produits");
        }
    }
}

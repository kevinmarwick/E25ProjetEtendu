using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E25ProjetEtendu.Migrations
{
    /// <inheritdoc />
    public partial class SeedProduit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    prix = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    estActif = table.Column<bool>(type: "bit", nullable: false),
                    note = table.Column<int>(type: "int", nullable: false),
                    valeurNutritive = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produits", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "produits",
                columns: new[] { "id", "Image", "Qty", "estActif", "nom", "note", "prix", "valeurNutritive" },
                values: new object[,]
                {
                    { 1, "redbull.jpg", 120, true, "Red Bull", 4, 3, "Calories: 110, Sucres: 27g, Caféine: 80mg, Glucides: 28g, Protéines: 1g" },
                    { 2, "pogo.jpg", 200, true, "Pogo", 3, 2, "Calories: 190, Lipides: 9g, Glucides: 20g, Protéines: 6g, Sodium: 500mg" },
                    { 3, "eau.jpg", 300, true, "Bouteille d'eau", 5, 1, "Calories: 0, Lipides: 0g, Sucres: 0g, Sodium: 0mg" },
                    { 4, "chips.jpg", 100, true, "Chips Lay’s", 4, 2, "Calories: 160, Lipides: 10g, Glucides: 15g, Sucres: 1g, Sodium: 170mg" },
                    { 5, "nutella.jpg", 80, true, "Nutella", 5, 5, "Calories: 200, Lipides: 11g, Glucides: 22g, Sucres: 21g, Protéines: 2g" },
                    { 6, "activia.jpg", 150, true, "Yogourt Activia", 4, 3, "Calories: 100, Lipides: 2g, Glucides: 15g, Sucres: 12g, Protéines: 5g" },
                    { 7, "pizza.jpg", 60, true, "Pizza congelée", 4, 6, "Calories: 350, Lipides: 15g, Glucides: 40g, Sucres: 5g, Protéines: 12g" },
                    { 8, "granola.jpg", 180, true, "Barre de granola", 4, 2, "Calories: 190, Lipides: 7g, Glucides: 29g, Sucres: 11g, Protéines: 4g" },
                    { 9, "coca.jpg", 220, true, "Coca-Cola", 3, 2, "Calories: 140, Sucres: 39g, Glucides: 39g, Sodium: 45mg" },
                    { 10, "sandwich.jpg", 75, true, "Sandwich jambon-fromage", 4, 4, "Calories: 320, Lipides: 12g, Glucides: 30g, Protéines: 18g, Sodium: 780mg" }
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

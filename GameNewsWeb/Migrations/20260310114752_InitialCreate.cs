using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameNewsWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Genre", "ImageUrl", "Platform", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "RPG", "assets/img/image 1.png", "PC", 2500m, 4.7999999999999998, "Split Fiction" },
                    { 2, "RPG", "assets/img/image 2.png", "PC, PS5, Xbox", 3500m, 4.5999999999999996, "Cyberpunk 2077" },
                    { 3, "MOBA", "assets/img/image 3.png", "PC", 0m, 4.7000000000000002, "Dota 2" },
                    { 4, "RPG", "", "PC, PS5, Xbox", 2000m, 4.9000000000000004, "The Witcher 3" },
                    { 5, "RPG", "", "PC, PS5", 4000m, 4.9000000000000004, "Baldur's Gate 3" },
                    { 6, "Action", "", "PC, PS5, Xbox", 3000m, 4.7000000000000002, "Red Dead Redemption 2" },
                    { 7, "Action", "", "PC, PS5, Xbox", 3200m, 4.2999999999999998, "Assassin's Creed Mirage" },
                    { 8, "Shooter", "", "PC", 0m, 4.5, "CS2" },
                    { 9, "Roguelike", "", "PC, Switch", 1500m, 4.4000000000000004, "Hades" },
                    { 10, "Simulator", "", "PC, Switch", 700m, 4.5999999999999996, "Stardew Valley" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}

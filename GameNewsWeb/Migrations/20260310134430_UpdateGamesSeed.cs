using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameNewsWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGamesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Genre", "ImageUrl", "Platform", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { 4, "RPG", "", "PC, PS5, Xbox", 2000m, 4.9000000000000004, "The Witcher 3" },
                    { 5, "RPG", "", "PC, PS5", 4000m, 4.9000000000000004, "Baldur's Gate 3" },
                    { 6, "Action", "", "PC, PS5, Xbox", 3000m, 4.7000000000000002, "Red Dead Redemption 2" },
                    { 7, "Action", "", "PC, PS5, Xbox", 3200m, 4.2999999999999998, "Assassin's Creed Mirage" },
                    { 8, "Shooter", "", "PC", 0m, 4.5, "CS2" },
                    { 9, "Roguelike", "", "PC, Switch", 1500m, 4.4000000000000004, "Hades" },
                    { 10, "Simulator", "", "PC, Switch", 700m, 4.5999999999999996, "Stardew Valley" }
                });
        }
    }
}

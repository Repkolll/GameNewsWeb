using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameNewsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Announces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announces", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Announces",
                columns: new[] { "Id", "Genre", "LinkUrl", "Platform", "Summary", "TimeText", "Title" },
                values: new object[,]
                {
                    { 1, "RPG", "announce-1.html", "PC", "Студия анонсировала новый проект в жанре фэнтези...", "сегодня в 10:00", "Анонс новой игры от CD Projekt RED" },
                    { 2, "Adventure", "announce-2.html", "PS5", "Новая часть серии выйдет в следующем году...", "вчера в 10:00", "Ubisoft представила трейлер Assassin's Creed" },
                    { 3, "Strategy", "announce-3.html", "Xbox", "Первое крупное дополнение к космической RPG...", "позавчера в 10:00", "Bethesda анонсировала Starfield DLC" },
                    { 4, "Adventure", "announce-4.html", "Switch", "Разработчики показали геймплей и дату релиза...", "4 дня назад", "Новая кооперативная игра на Switch" },
                    { 5, "Strategy", "announce-5.html", "PC", "Анонсирована новая стратегия с упором на кампанию...", "неделю назад", "Тактическая стратегия для PC" }
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { "Split Fiction — сюжетная RPG в научно‑фантастическом сеттинге.", "ОС: Windows 10 64-bit; CPU: i5/Ryzen 5; RAM: 16 GB; GPU: GTX 1060/RX 580; Место: 80 GB" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { "Cyberpunk 2077 — ролевая игра в открытом мире Найт‑Сити.", "ОС: Windows 10 64-bit; CPU: i7/Ryzen 5; RAM: 12 GB; GPU: GTX 1060 6GB/RX 580 8GB; Место: 70 GB" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { "Dota 2 — командная MOBA с глубокой механикой и киберспортом.", "ОС: Windows 10 64-bit; CPU: 2.8 GHz dual‑core; RAM: 8 GB; GPU: GeForce 8600/Radeon HD2600; Место: 50 GB" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announces");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Games");
        }
    }
}

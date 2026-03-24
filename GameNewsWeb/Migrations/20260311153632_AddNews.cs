using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameNewsWeb.Migrations
{
    /// <inheritdoc />
    public partial class AddNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "ImageUrl", "LinkUrl", "Summary", "TimeText", "Title" },
                values: new object[,]
                {
                    { 1, "assets/img/Rectangle 8.png", "news-1.html", "Хакеры удалили Denuvo из Tourist Bus Simulator и обещают...", "сегодня в 13:00", "SKIDROW наконец-то сделали это..." },
                    { 2, "assets/img/Rectangle 10.png", "news-2.html", "Подробности апдейта и совместимости GPU...", "сегодня в 11:40", "Время апгрейда: Silent Hill f не работает на RTX 5090" },
                    { 3, "assets/img/Rectangle 12.png", "news-3.html", "«Лучшая научно-фантастическая игра» на Galaxy Sci-Fi...", "вчера в 10:00", "Cyberpunk 2077 получила награду" },
                    { 4, "assets/img/Rectangle 10.png", "news-4.html", "Собрали самые интересные инди-релизы недели...", "3 дня назад в 15:30", "Подборка свежих инди-игр недели" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}

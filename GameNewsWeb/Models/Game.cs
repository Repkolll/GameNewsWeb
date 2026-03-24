namespace GameNewsWeb.Models
{
    public class Game
    {
        public int Id { get; set; }            // PK
        public string Title { get; set; } = ""; // название
        public string Genre { get; set; } = ""; // жанр (RPG, Shooter, MOBA...)
        public string Platform { get; set; } = ""; // платформа (PC, PS5, Xbox...)
        public decimal Price { get; set; }      // цена
        public double Rating { get; set; }      // рейтинг 0–5
        public string ImageUrl { get; set; } = "";
        public string Description { get; set; } = "";
        public string Requirements { get; set; } = "";
    }
}
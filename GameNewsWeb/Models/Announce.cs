namespace GameNewsWeb.Models
{
    public class Announce
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Summary { get; set; } = "";
        public string TimeText { get; set; } = "";
        public string Platform { get; set; } = ""; // PC, PS5, Xbox, Switch
        public string Genre { get; set; } = "";    // RPG, Strategy, Adventure...
        public string LinkUrl { get; set; } = "";
    }
}
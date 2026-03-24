namespace GameNewsWeb.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Summary { get; set; } = "";
        public string TimeText { get; set; } = "";   // "сегодня в 13:00" и т.п.
        public string ImageUrl { get; set; } = "";
        public string LinkUrl { get; set; } = "";    // news-1.html и т.п.
    }
}
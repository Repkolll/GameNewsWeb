using GameNewsWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GameNewsWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<NewsItem> News { get; set; }
        public DbSet<Announce> Announces { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
         
            modelBuilder.Entity<Game>()
                .Property(g => g.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Title = "Split Fiction",
                    Genre = "RPG",
                    Platform = "PC",
                    Price = 2500,
                    Rating = 4.8,
                    ImageUrl = "assets/img/image 1.png",
                    Description = "Split Fiction — сюжетная RPG в научно‑фантастическом сеттинге.",
                    Requirements = "ОС: Windows 10 64-bit; CPU: i5/Ryzen 5; RAM: 16 GB; GPU: GTX 1060/RX 580; Место: 80 GB"
                },
                new Game
                {
                    Id = 2,
                    Title = "Cyberpunk 2077",
                    Genre = "RPG",
                    Platform = "PC, PS5, Xbox",
                    Price = 3500,
                    Rating = 4.6,
                    ImageUrl = "assets/img/image 2.png",
                    Description = "Cyberpunk 2077 — ролевая игра в открытом мире Найт‑Сити.",
                    Requirements = "ОС: Windows 10 64-bit; CPU: i7/Ryzen 5; RAM: 12 GB; GPU: GTX 1060 6GB/RX 580 8GB; Место: 70 GB"
                },
                new Game
                {
                    Id = 3,
                    Title = "Dota 2",
                    Genre = "MOBA",
                    Platform = "PC",
                    Price = 0,
                    Rating = 4.7,
                    ImageUrl = "assets/img/image 3.png",
                    Description = "Dota 2 — командная MOBA с глубокой механикой и киберспортом.",
                    Requirements = "ОС: Windows 10 64-bit; CPU: 2.8 GHz dual‑core; RAM: 8 GB; GPU: GeForce 8600/Radeon HD2600; Место: 50 GB"
                }
            );
            modelBuilder.Entity<NewsItem>().HasData(
                new NewsItem
                {
                    Id = 1,
                    Title = "SKIDROW наконец-то сделали это...",
                    Summary = "Хакеры удалили Denuvo из Tourist Bus Simulator и обещают...",
                    TimeText = "сегодня в 13:00",
                    ImageUrl = "assets/img/Rectangle 8.png",
                    LinkUrl = "news-1.html"
                },
                new NewsItem
                {
                    Id = 2,
                    Title = "Время апгрейда: Silent Hill f не работает на RTX 5090",
                    Summary = "Подробности апдейта и совместимости GPU...",
                    TimeText = "сегодня в 11:40",
                    ImageUrl = "assets/img/Rectangle 10.png",
                    LinkUrl = "news-2.html"
                },
                new NewsItem
                {
                    Id = 3,
                    Title = "Cyberpunk 2077 получила награду",
                    Summary = "«Лучшая научно-фантастическая игра» на Galaxy Sci-Fi...",
                    TimeText = "вчера в 10:00",
                    ImageUrl = "assets/img/Rectangle 12.png",
                    LinkUrl = "news-3.html"
                },
                new NewsItem
                {
                    Id = 4,
                    Title = "Подборка свежих инди-игр недели",
                    Summary = "Собрали самые интересные инди-релизы недели...",
                    TimeText = "3 дня назад в 15:30",
                    ImageUrl = "assets/img/Rectangle 10.png",
                    LinkUrl = "news-4.html"
                }
            );

            modelBuilder.Entity<Announce>().HasData(
                new Announce { Id = 1, Title = "Анонс новой игры от CD Projekt RED", Summary = "Студия анонсировала новый проект в жанре фэнтези...", TimeText = "сегодня в 10:00", Platform = "PC", Genre = "RPG", LinkUrl = "announce-1.html" },
                new Announce { Id = 2, Title = "Ubisoft представила трейлер Assassin's Creed", Summary = "Новая часть серии выйдет в следующем году...", TimeText = "вчера в 10:00", Platform = "PS5", Genre = "Adventure", LinkUrl = "announce-2.html" },
                new Announce { Id = 3, Title = "Bethesda анонсировала Starfield DLC", Summary = "Первое крупное дополнение к космической RPG...", TimeText = "позавчера в 10:00", Platform = "Xbox", Genre = "Strategy", LinkUrl = "announce-3.html" },
                new Announce { Id = 4, Title = "Новая кооперативная игра на Switch", Summary = "Разработчики показали геймплей и дату релиза...", TimeText = "4 дня назад", Platform = "Switch", Genre = "Adventure", LinkUrl = "announce-4.html" },
                new Announce { Id = 5, Title = "Тактическая стратегия для PC", Summary = "Анонсирована новая стратегия с упором на кампанию...", TimeText = "неделю назад", Platform = "PC", Genre = "Strategy", LinkUrl = "announce-5.html" }
            );
        }
    }
}
// Controllers/GamesController.cs
using GameNewsWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameNewsWeb.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? search, string? genre)
        {
            var query = _context.Games.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(g => g.Title.Contains(search));

            if (!string.IsNullOrWhiteSpace(genre))
                query = query.Where(g => g.Genre == genre);

            ViewBag.Search = search;
            ViewBag.Genre = genre;

            var games = await query.ToListAsync();
            return View(games);
        }
    }
}
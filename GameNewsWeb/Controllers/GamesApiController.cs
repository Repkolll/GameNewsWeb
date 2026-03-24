using GameNewsWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameNewsWeb.Models;
using System.IO;

namespace GameNewsWeb.Controllers
{
    public class GameCreateDto
    {
        public string Title { get; set; } = "";
        public string Genre { get; set; } = "";
        public string Platform { get; set; } = "";
        public decimal Price { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; } = "";
        public string Requirements { get; set; } = "";
        public IFormFile? Image { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class GamesApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GamesApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /api/gamesapi
        [HttpGet]
        public async Task<IActionResult> GetGames(
            string? search,
            string? genre,
            decimal? priceMin,
            decimal? priceMax,
            double? ratingMin,
            double? ratingMax)
        {
            var query = _context.Games.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(g => g.Title.Contains(search));

            if (!string.IsNullOrWhiteSpace(genre))
                query = query.Where(g => g.Genre == genre);

            if (priceMin.HasValue)
                query = query.Where(g => g.Price >= priceMin.Value);

            if (priceMax.HasValue)
                query = query.Where(g => g.Price <= priceMax.Value);

            if (ratingMin.HasValue)
                query = query.Where(g => g.Rating >= ratingMin.Value);

            if (ratingMax.HasValue)
                query = query.Where(g => g.Rating <= ratingMax.Value);

            var games = await query.ToListAsync();


            var result = games.Select(g => new
            {
                id = g.Id,
                title = g.Title,
                genre = g.Genre,
                platform = g.Platform,
                price = g.Price,
                rating = g.Rating,
                imageUrl = g.ImageUrl
            });

            return Ok(result);
        }

        // GET: /api/gamesapi/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGameDetails(int id)
        {
            var g = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            if (g == null) return NotFound();

            var result = new
            {
                id = g.Id,
                title = g.Title,
                genre = g.Genre,
                platform = g.Platform,
                price = g.Price,
                rating = g.Rating,
                imageUrl = g.ImageUrl,
                description = g.Description,
                requirements = g.Requirements
            };

            return Ok(result);
        }

        // POST: /api/gamesapi
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromForm] GameCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title) || dto.Title.Trim().Length < 2)
                return BadRequest("Bad title");
            if (string.IsNullOrWhiteSpace(dto.Genre))
                return BadRequest("Bad genre");
            if (string.IsNullOrWhiteSpace(dto.Platform))
                return BadRequest("Bad platform");
            if (dto.Price < 0) return BadRequest("Bad price");
            if (dto.Rating < 0 || dto.Rating > 5) return BadRequest("Bad rating");
            if (string.IsNullOrWhiteSpace(dto.Description) || dto.Description.Trim().Length < 10)
                return BadRequest("Bad description");
            if (string.IsNullOrWhiteSpace(dto.Requirements) || dto.Requirements.Trim().Length < 10)
                return BadRequest("Bad requirements");
            if (dto.Image == null || dto.Image.Length == 0)
                return BadRequest("Image required");

            var ext = Path.GetExtension(dto.Image.FileName).ToLowerInvariant();
            if (ext != ".png" && ext != ".jpg" && ext != ".jpeg")
                return BadRequest("Bad image type");

            var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            Directory.CreateDirectory(uploadsDir);

            var fileName = $"{Guid.NewGuid():N}{ext}";
            var filePath = Path.Combine(uploadsDir, fileName);

            using (var fs = System.IO.File.Create(filePath))
                await dto.Image.CopyToAsync(fs);

            var imageUrl = $"/uploads/{fileName}";

            var game = new Game
            {
                Title = dto.Title.Trim(),
                Genre = dto.Genre,
                Platform = dto.Platform.Trim(),
                Price = dto.Price,
                Rating = dto.Rating,
                ImageUrl = imageUrl,
                Description = dto.Description.Trim(),
                Requirements = dto.Requirements.Trim()
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                id = game.Id,
                title = game.Title,
                genre = game.Genre,
                platform = game.Platform,
                price = game.Price,
                rating = game.Rating,
                imageUrl = game.ImageUrl
            });
        }

        // DELETE: /api/gamesapi/123
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
            if (game == null) return NotFound();

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
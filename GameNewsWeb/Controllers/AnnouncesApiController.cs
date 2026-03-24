using GameNewsWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameNewsWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnnouncesApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AnnouncesApiController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/announcesapi?platform=PC&genre=RPG
        [HttpGet]
        public async Task<IActionResult> GetAnnounces(string? platform, string? genre)
        {
            var q = _context.Announces.AsQueryable();

            if (!string.IsNullOrWhiteSpace(platform))
                q = q.Where(a => a.Platform == platform);

            if (!string.IsNullOrWhiteSpace(genre))
                q = q.Where(a => a.Genre == genre);

            var items = await q.OrderBy(a => a.Id).ToListAsync();
            return Ok(items);
        }
    }
}
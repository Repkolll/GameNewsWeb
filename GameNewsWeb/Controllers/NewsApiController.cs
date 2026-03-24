using GameNewsWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameNewsWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NewsApiController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetNews(int skip = 3, int take = 3)
        {
            var items = await _context.News
                .OrderBy(n => n.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return Ok(items);
        }
    }
}
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PostController : Controller
    {
        private readonly ForumDbContext context;

        public PostController(ForumDbContext _context)
        {
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await context.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return View(model);
        }
    }
}

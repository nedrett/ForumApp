using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    using Data;
    using Data.Models;
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


        public IActionResult Add()
        {
            var model = new PostViewModel();

            ViewData["Title"] = "Add new Post";

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = model.Id == 0 ? "Add new Post" : "Edit Post";

                return View(model);
            }

            if (model.Id == 0)
            {
                context.Posts.Add(new Post()
                {
                    Title = model.Title,
                    Content = model.Content
                });
            }
            else
            {
                var post = await context.Posts.FindAsync(model.Id);

                if (post != null)
                {
                    post.Title = model.Title;
                    post.Content = model.Content;
                }
            }

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Unit3Reddit.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Unit3Reddit.Controllers
{
    public class ForumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Forums/Index
        public async Task<IActionResult> Index()
        {
            var forums = await _context.Forums.ToListAsync(); // Fetch all forums from the database
            return View(forums); // Pass the list of forums to the view
        }

        // GET: Forums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var forum = await _context.Forums
                .Include(f => f.Posts) // Include related posts
                .ThenInclude(p => p.User) // Include users associated with the posts
                .FirstOrDefaultAsync(m => m.ForumId == id);

            if (forum == null)
            {
                return NotFound();
            }

            return View(forum); // Pass the forum details to the view
        }

        // GET: Forums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forums/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ForumId,Name,Description")] Forum forum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forum); // Add the new forum to the database
                await _context.SaveChangesAsync(); // Save changes asynchronously
                return RedirectToAction(nameof(Index)); // Redirect to the Index action
            }
            return View(forum);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Models;

namespace ProjectDbStarter.Controllers
{
    public class TeamController : Controller
    {
        private readonly BowlingDbContext _db;

        public TeamController(BowlingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Order for predictable display
            var teams = _db.Teams.ToList();

            return View(teams);
        }

        // TODO: Shows a list of paid teams
        [HttpGet]
        public IActionResult Paid()
        {
            return View();
        }

        // TODO: Shows a READ ONLY details for a team including players
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

        // TODO: Shows a view for registering a team form
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // TODO: Adds the team in the db if it meets criteria
        [HttpPost]
        public IActionResult Register(TeamViewModel vm)
        {
            return View();
        }
    }
}

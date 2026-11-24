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

        // [DONE]: Shows a list of paid teams
        [HttpGet]
        public IActionResult Paid()
        {
            var teams = _db.Teams
                .Where(t => t.RegistrationPaid)
                .OrderBy(t => t.TeamId)
                .ToList();

            return View(teams);
        }

        // [DONE]: Shows a READ ONLY details for a team including players
        [HttpGet]
        public IActionResult Details(int id)
        {
            var team = _db.Teams.FirstOrDefault(t => t.TeamId == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        // [DONE]: Shows a view for registering a team form
        [HttpGet]
        public IActionResult Register()
        {
            return View(new TeamViewModel());
        }

        // [DONE]: Adds the team in the db if it meets criteria
        [HttpPost]
        public IActionResult Register(TeamViewModel vm)
        {
            if (string.IsNullOrWhiteSpace(vm.TeamName))
            {
                ModelState.AddModelError(nameof(vm.TeamName), "Team name is required.");
            }
            else
            {
                bool duplicateExists = _db.Teams.Any(t =>
                    t.TeamName.ToLower() == vm.TeamName.Trim().ToLower()
                );
                if (duplicateExists)
                {
                    ModelState.AddModelError(nameof(vm.TeamName), "Team name already exists.");
                }
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var team = new Team
            {
                TeamName = vm.TeamName.Trim(),
                RegistrationPaid = false,
                PaymentDate = null
            };
            _db.Teams.Add(team);
            _db.SaveChanges();

            return View();
        }
    }
}

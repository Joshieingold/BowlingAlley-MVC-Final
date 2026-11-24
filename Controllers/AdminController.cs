using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Models;

namespace ProjectDbStarter.Controllers
{
    public class AdminController : Controller
    {
        private readonly BowlingDbContext _db;

        public AdminController(BowlingDbContext db)
        {
            _db = db;
        }

        // TODO: Lists teams with filters by divison, paid/unpaid
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Index(string? division, bool? paid)
        {
            return View();
        }

        // TODO: Shows The TeamEditVm
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult CreateTeam()
        {
            return View();
        }

        // TODO: Add The TeamEditVm as a Team Obj to Db if meets requirements
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult CreateTeam(TeamViewModel vm)
        {
            return View();
        }

        // TODO: Get the Team from id and show it in the view
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult EditTeam(int id)
        {
            return View();
        }

        // TODO: Update the Team from The ViewModel in the db
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult EditTeam(TeamViewModel vm)
        {
            return View();
        }

        // TODO: Populates the delete page with view model populated with team data
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteTeam(int id)
        {
            return View();
        }

        // TODO: Deletes the team in the database on confirmation
        [HttpPost, ActionName("DeleteTeam")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DeleteTeamConfirm(int id)
        {
            return View();
        }

        // TODO: Shows all the players in a model
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult ManagePlayers(int teamId)
        {
            return View();
        }

        // TODO: Shows The PlayerVm
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AddPlayer()
        {
            return View();
        }

        // TODO: Add The Player as a Player Obj to Db if meets requirements
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult AddPlayer(PlayerEditViewModel vm)
        {
            return View();
        }

        // TODO: Remove The Player from Db
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult RemovePlayer(int id)
        {
            return View();
        }

        // TODO: Change a teams status to paid or not paid
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult UpdatePaid(int id)
        {
            return View();
        }

        // TODO: Shows overall registration summary
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Summary()
        {
            return View();
        }

        // TODO: Shows registration summary grouped by division
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult DivisionSummary()
        {
            return View();
        }
    }
}

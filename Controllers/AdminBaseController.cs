using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Models;

namespace ProjectDbStarter.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [Route("Admin")]
    public class AdminController(BowlingDbContext db) : Controller
    {
        //NOTE: THIS IS SOME MAGIC I MAY REGRET TRYING TO PULL LATER
        // Lists teams with filters by divison, paid/unpaid
        [HttpGet("")]
        [Authorize(Policy = "AdminOnly")]
        public IActionResult Index(string? division, bool? paid)
        {
            return View("~/Views/Admin/Index.cshtml");
        }
    }
}

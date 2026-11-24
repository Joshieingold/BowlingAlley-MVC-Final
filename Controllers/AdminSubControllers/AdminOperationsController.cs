using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Controllers;
using ProjectDbStarter.Models;

[Authorize(Policy = "AdminOnly")]
[Route("Admin/Operations/[action]")]
public class AdminOperationsController(BowlingDbContext db) : AdminController(db)
{
    // TODO: Change a teams status to paid or not paid
    [HttpPost]
    public IActionResult UpdatePaid(int id)
    {
        return View();
    }

    // TODO: Shows overall registration summary
    [HttpGet]
    public IActionResult Summary()
    {
        return View();
    }

    // TODO: Shows registration summary grouped by division
    [HttpGet]
    public IActionResult DivisionSummary()
    {
        return View();
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Controllers;
using ProjectDbStarter.Models;

[Route("Admin/Teams/[action]")]
[Authorize(Policy = "AdminOnly")]
// Once again this is the new way to do Dependency Injection
public class AdminTeamsController(BowlingDbContext db) : AdminController(db)
{
    // TODO: Shows The TeamEditVm
    [HttpGet]
    public IActionResult CreateTeam()
    {
        return View();
    }

    // TODO: Add The TeamEditVm as a Team Obj to Db if meets requirements
    [HttpPost]
    public IActionResult CreateTeam(TeamViewModel vm)
    {
        return View();
    }

    // TODO: Get the Team from id and show it in the view
    [HttpGet]
    public IActionResult EditTeam(int id)
    {
        return View();
    }

    // TODO: Update the Team from The ViewModel in the db
    [HttpPost]
    public IActionResult EditTeam(TeamViewModel vm)
    {
        return View();
    }

    // TODO: Populates the delete page with view model populated with team data
    [HttpGet]
    public IActionResult DeleteTeam(int id)
    {
        return View();
    }

    // TODO: Deletes the team in the database on confirmation
    [HttpPost, ActionName("DeleteTeam")]
    public IActionResult DeleteTeamConfirm(int id)
    {
        return View();
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Controllers;
using ProjectDbStarter.Models;

[Authorize(Policy = "AdminOnly")]
[Route("Admin/Rosters/[action]")]
public class AdminRostersController(BowlingDbContext db) : AdminController(db)
{
    // TODO: Shows all the players in a model
    [HttpGet]
    public IActionResult ManagePlayers(int teamId)
    {
        return View();
    }

    // TODO: Shows The PlayerVm
    [HttpGet]
    public IActionResult AddPlayer()
    {
        return View();
    }

    // TODO: Add The Player as a Player Obj to Db if meets requirements
    [HttpPost]
    public IActionResult AddPlayer(PlayerViewModel vm)
    {
        return View();
    }

    // TODO: Shows the form to Edit the players data
    [HttpGet]
    public IActionResult EditPlayer()
    {
        return View();
    }

    // TODO: Update The Player as a Player Obj to Db if meets requirements
    [HttpPost]
    public IActionResult EditPlayer(PlayerViewModel vm)
    {
        return View();
    }

    // TODO: Remove The Player from Db
    [HttpPost]
    public IActionResult RemovePlayer(int id)
    {
        return View();
    }
}

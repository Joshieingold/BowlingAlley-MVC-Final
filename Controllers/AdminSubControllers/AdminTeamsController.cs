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
        // Simple life :)
        return View(new TeamViewModel());
    }

    // TODO: Add The TeamEditVm as a Team Obj to Db if meets requirements
    [HttpPost]
    public IActionResult CreateTeam(TeamViewModel vm)
    {
        try
        {
            Team newTeam = ConvertToDbObject(vm);
            db.Teams.Add(newTeam);
            db.SaveChanges();
            // This should go to the place where everything is listed.
            return View();
        }
        catch (Exception ex)
        {
            // This should be some error location
            return View();
        }
    }

    // Get the Team from id and show it in the view
    [HttpGet]
    public IActionResult EditTeam(int id)
    {
        Team? foundTeam = db.Teams.FirstOrDefault(t => t.TeamId == id);
        // Shouldnt be null
        if (foundTeam == null)
        {
            return View();
        }
        TeamViewModel tvo = ConvertToModel(foundTeam);
        return View(tvo);
    }

    // Update the Team from The ViewModel in the db
    [HttpPost]
    public IActionResult EditTeam(TeamViewModel vm)
    {
        try
        {
            Team t = ConvertToDbObject(vm);
            db.Teams.Update(t);
            db.SaveChanges();
            return View();
        }
        catch (Exception ex)
        {
            return View();
        }
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

    ////////////////////////
    // Conversion Helpers //
    ////////////////////////

    private TeamViewModel ConvertToModel(Team t)
    {
        TeamViewModel model = new()
        {
            TeamName = t.TeamName,
            TeamDivision = t.TeamDivision,
            RegistrationPaid = t.RegistrationPaid,
        };
        // Doesnt get set unless they have paid
        if (model.RegistrationPaid)
        {
            model.PaymentDate = t.PaymentDate;
        }
        return model;
    }

    private Team ConvertToDbObject(TeamViewModel tvm)
    {
        Team model = new()
        {
            TeamName = tvm.TeamName,
            TeamDivision = tvm.TeamDivision,
            RegistrationPaid = tvm.RegistrationPaid,
        };
        // Doesnt get set unless they have paid
        if (model.RegistrationPaid)
        {
            model.PaymentDate = tvm.PaymentDate;
        }
        return model;
    }
}

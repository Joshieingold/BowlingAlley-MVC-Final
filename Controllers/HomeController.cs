using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Models;

namespace ProjectDbStarter.Controllers;

public class TeamInfo
{

    //Basic information regarding every team, including the team name, division,
    //registration status, and registration date.

    public int TeamId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public int Division { get; set; }
    public bool RegPaid { get; set; }
    public string? RegDate { get; set; }
    public List<string> Players { get; set; } = new();
}

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var BowlingTeams = new List<TeamInfo>
        {

            //List of all teams

            new()
            {
                TeamId = 36,
                TeamName = "Lucky Laners",
                Division = 2,
                RegPaid = true,
                RegDate = "2026-05-09",
                Players = ["Jamie Doman", "Russell Griswold", "Alex Vance", "Owen Wonne"]
            },
            new()
            {
                TeamId = 37,
                TeamName = "Women in STEM",
                Division = 4,
                RegPaid = false,
                RegDate = null,
                Players = ["McLovin", "Brody Sailor", "Sam Altman", "John Deadlock"]
            },
            new()
            {
                TeamId = 38,
                TeamName = "Super Intelligence Team",
                Division = 5,
                RegPaid = false,
                RegDate = null,
                Players = ["Abigail Callaghan", "Lex Luthor", "Connie Layes", "Wade Wilson"]
            },
            new()
            {
                TeamId = 39,
                TeamName = "Team Four Star",
                Division = 1,
                RegPaid = true,
                RegDate = "2026-05-23",
                Players = ["Joe Mama", "Jim Lahey", "Rita Martin", "Emily French"]
            },
            new()
            {
                TeamId = 40,
                TeamName = "Fireballs",
                Division = 3,
                RegPaid = true,
                RegDate = "2026-05-08",
                Players = ["Sophie Chatterton", "Kailey Roberts", "Rory Hughes", "Steve Harrington"]
            }
        };

        return View(BowlingTeams);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
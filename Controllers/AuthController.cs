using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Models;

namespace ProjectDbStarter.Controllers;

public class AuthController : Controller
{
    private readonly BowlingDbContext _db;

    public AuthController(BowlingDbContext db)
    {
        _db = db;
    }

    // TODO: Shows the logins page
    [HttpGet]
    public IActionResult Login()
    {
        LoginViewModel vm = new LoginViewModel();
        return View(vm);
    }

    // TODO: posts the login form and verifies credentials to login
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        BowlingUser? user = _db.Users.FirstOrDefault(u => u.UserName == vm.Username);
        // Make sure theyre not null
        if (user == null)
        {
            return View(vm);
        }

        // Claims
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("IsAdmin", user.IsAdmin ? "true" : "false"),
        };

        ClaimsIdentity ci = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme
        );
        ClaimsPrincipal p = new ClaimsPrincipal(ci);

        await HttpContext.SignInAsync(p);
        return RedirectToAction("Index", "Home");
    }

    // TODO: Logs the user out and redirects.
    [HttpPost]
    public IActionResult Logout()
    {
        return RedirectToAction("Index", "Home");
    }
}

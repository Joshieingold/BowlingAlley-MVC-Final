using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Models;

namespace ProjectDbStarter.Controllers;

// Old way triggers IDE0290, so this is how Im doing the Dependency Injection
public class AuthController(BowlingDbContext db) : Controller
{
    // Shows the login page with a blank View Model
    [HttpGet]
    public IActionResult Login()
    {
        // Just pass a plain LoginViewModel
        return View(new LoginViewModel());
    }

    // Posts the login form and verifies credentials to login
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel vm)
    {
        // Find the user
        BowlingUser? user = db.Users.FirstOrDefault(u => u.UserName == vm.Username);
        // when the user is not found return
        if (user == null)
        {
            ModelState.AddModelError("", "Incorrect Username or Password");
            return View(vm);
        }

        // Make sure the password is correct
        PasswordHasher<BowlingUser> passHasher = new();
        if (
            passHasher.VerifyHashedPassword(user, user.PasswordHash, vm.Password)
            == PasswordVerificationResult.Failed
        )
        {
            ModelState.AddModelError("", "Incorrect Username or Password");
            return View(vm);
        }

        // Claims
        // CS RECOMMENDS THIS NEW SYNTAX
        List<Claim> claims =
        [
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("IsAdmin", user.IsAdmin ? "true" : "false"),
        ];

        ClaimsIdentity ci = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        ClaimsPrincipal p = new(ci);

        await HttpContext.SignInAsync(p);
        return RedirectToAction("Index", "Home");
    }

    // User is logged out and cookie is removed
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}

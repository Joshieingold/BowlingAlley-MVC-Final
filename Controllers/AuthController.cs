using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectDbStarter.Models;

namespace ProjectDbStarter.Controllers;

public class AuthController : Controller
{
    // TODO: Shows the logins page
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // TODO: posts the login form and verifies credentials to login
    [HttpPost]
    public IActionResult Login(LoginViewModel vm)
    {
        return View();
    }

    // TODO: Logs the user out and redirects.
    [HttpPost]
    public IActionResult Logout()
    {
        return View();
    }
}

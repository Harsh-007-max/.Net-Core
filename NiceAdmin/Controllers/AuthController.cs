using Microsoft.AspNetCore.Mvc;

namespace NiceAdmin.Controllers;

public class AuthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("Login");
    }

    public IActionResult Register()
    {
        return View("pagesRegister");
    }
}
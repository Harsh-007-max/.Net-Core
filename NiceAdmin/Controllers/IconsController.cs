using Microsoft.AspNetCore.Mvc;

namespace NiceAdmin.Controllers;

public class IconsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("BootstrapIcons");
    }

    public IActionResult IconsRemix()
    {
        return View();
    }

    public IActionResult IconsBoxicons()
    {
        return View();
    }
}
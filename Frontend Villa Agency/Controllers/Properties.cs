using Microsoft.AspNetCore.Mvc;

namespace Frontend_Villa_Agency.Controllers;

public class Properties : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult PropertyDetails()
    {
        return View();
    }
}
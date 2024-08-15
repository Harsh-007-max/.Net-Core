using Microsoft.AspNetCore.Mvc;

namespace NiceAdmin.Controllers;

public class TablesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("GeneralTable");
    }

    public IActionResult TablesData()
    {
        return View();
    }
}
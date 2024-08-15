using Microsoft.AspNetCore.Mvc;

namespace NiceAdmin.Controllers;

public class FormsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("FormsElements");
    }

    public IActionResult FormsLayouts()
    {
        return View();
    }

    public IActionResult FormsEditors()
    {
        return View();
    }

    public IActionResult FormsValidation()
    {
        return View();
    }
}
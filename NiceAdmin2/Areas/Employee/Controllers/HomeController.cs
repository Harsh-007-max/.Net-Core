using Microsoft.AspNetCore.Mvc;

namespace NiceAdmin2.Areas.Employee.Controllers;

[Area("Employee")]
public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
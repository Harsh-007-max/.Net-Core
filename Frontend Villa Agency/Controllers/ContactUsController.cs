using Microsoft.AspNetCore.Mvc;

namespace Frontend_Villa_Agency.Controllers;

public class ContactUsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}
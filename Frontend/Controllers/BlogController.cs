using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers;

public class BlogController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("Blog");
    }
    
    public IActionResult BlogSingle()
    {
        return View();
    }
}
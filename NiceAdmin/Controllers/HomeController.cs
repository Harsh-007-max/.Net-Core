using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NiceAdmin.Models;

namespace NiceAdmin.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult userProfile()
    {
        return View();
    }

    public IActionResult pagesFaq()
    {
        return View();
    }

    public IActionResult pagesContact()
    {
        return View();
    }

    public IActionResult pagesRegister()
    {
        return View();
    }

    public IActionResult error404()
    {
        return View();
    }

    public IActionResult pagesBlank()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
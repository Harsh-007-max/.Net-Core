using Microsoft.AspNetCore.Mvc;

namespace NiceAdmin.Controllers;

public class ComponentsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("componentsAlert");
    }

    public IActionResult componentsAccordian()
    {
        return View();
    }

    public IActionResult componentsBadges()
    {
        return View();
    }

    public IActionResult componentsBreadcrumbs()
    {
        return View();
    }

    public IActionResult componentsButton()
    {
        return View();
    }

    public IActionResult componentsCards()
    {
        return View();
    }

    public IActionResult componentsCarousel()
    {
        return View();
    }

    public IActionResult componentsListGroup()
    {
        return View();
    }

    public IActionResult componentsModel()
    {
        return View();
    }

    public IActionResult componentsTabs()
    {
        return View();
    }

    public IActionResult componentsPagination()
    {
        return View();
    }

    public IActionResult componentsProgress()
    {
        return View();
    }

    public IActionResult componentsSpinners()
    {
        return View();
    }

    public IActionResult componentsTooltips()
    {
        return View();
    }
}
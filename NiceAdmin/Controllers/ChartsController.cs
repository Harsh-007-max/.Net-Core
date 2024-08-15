using Microsoft.AspNetCore.Mvc;

namespace NiceAdmin.Controllers;

public class ChartsController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View("chartsChartjs");
    }

    public IActionResult ApexCharts()
    {
        return View();
    }

    public IActionResult chartsEcharts()
    {
        return View();
    }
}
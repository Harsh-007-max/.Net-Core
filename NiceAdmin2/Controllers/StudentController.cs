using Microsoft.AspNetCore.Mvc;
using NiceAdmin2.Models;

namespace NiceAdmin2.Controllers;

public class StudentController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddEditStudent()
    {
        
        return View();
    }

    public IActionResult Save(Student student)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }
        else
        {
            return View("AddEditStudent",student);
        }
    }
}
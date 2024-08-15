using Microsoft.AspNetCore.Mvc;
using NiceAdmin2.Models;
using System.Data.SqlClient;
using System.Data;

namespace NiceAdmin2.Controllers;

public class Bills : Controller
{
    private IConfiguration configuration;

    public Bills(IConfiguration _configuration)
    {
        configuration = _configuration;
    }
    // GET
    public IActionResult Index()
    {
        string connectionString = this.configuration.GetConnectionString("ConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "PR_Bills_SelectAll";
        SqlDataReader reader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load(reader);
        return View(table);
    }

    public IActionResult AddEditBills()
    {
        return View();
    }

    public IActionResult Save(BillsModel bill)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index",bill);
        }

        return View("AddEditBills",bill);
    }
}
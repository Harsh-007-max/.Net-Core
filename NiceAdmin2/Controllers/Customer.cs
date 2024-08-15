using Microsoft.AspNetCore.Mvc;
using NiceAdmin2.Models;
using System.Data.SqlClient;
using System.Data;

namespace NiceAdmin2.Controllers;

public class Customer : Controller
{
    private IConfiguration configuration;

    public Customer(IConfiguration _configuration)
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
        command.CommandText = "PR_Customer_SelectAll";
        SqlDataReader reader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load(reader);
        return View(table);
    }

    public IActionResult AddEditCustomer()
    {
        return View();
    }

    public IActionResult Save(CustomerModel customer)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index",customer);
        }
        return View("AddEditCustomer",customer);
    }
}
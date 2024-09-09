using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class CustomerController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;

    public CustomerController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
    }
    // GET
    public IActionResult Index()
    {
        DataTable allCustomers = this._sqlHelper.ExecuteStoredProcedure("PR_Customer_SelectAll");
        return View(allCustomers);
    }

    public IActionResult AddEditCustomer()
    {
        return View();
    }
    public IActionResult CustomerSave(CustomerModel customer)
    {
        if (ModelState.IsValid)
        {
            return View("Index");
        }
        return View("AddEditCustomer");
    }

    public IActionResult DeleteCustomer(int customerId)
    {
        Dictionary<string,object> parameters = new Dictionary<string,object>
        {
            {"@CID",customerId}
        };
        _sqlHelper.ExecuteStoredProcedure("PR_Customer_DeleteByPK", parameters);
        return RedirectToAction("Index");
    }
}
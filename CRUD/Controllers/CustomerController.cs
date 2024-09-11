using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class CustomerController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    private FillDropdown _fillDropdown;
    public CustomerController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
        _fillDropdown = new FillDropdown();
    }
    // GET
    public IActionResult Index()
    {
        DataTable allCustomers = this._sqlHelper.ExecuteStoredProcedure("PR_Customer_SelectAll")!;
        return View(allCustomers);
    }

    public IActionResult AddEditCustomer(int? CustomerID)
    {
        DataTable userDropdown = _sqlHelper.ExecuteStoredProcedure("PR_User_DropDown")!;
        List<UserDropDownModel> userDropDownList = _fillDropdown.FIllDropDown<UserDropDownModel>(userDropdown);
        CustomerModel customer = new CustomerModel();
        if (CustomerID != null)
        {
            customer = _sqlHelper.GetByID<CustomerModel>("PR_Customer_SelectByPK", "@CustomerID", CustomerID ?? 1);
        }
        ViewBag.UserList = userDropDownList;
        return View(customer);
    }
    public IActionResult CustomerSave(CustomerModel customer)
    {
        if (ModelState.IsValid)
        {
            if (customer.CustomerID > 0)
            {
                _sqlHelper.PerformSqlOperation<CustomerModel>(customer, "PR_Customer_UpdateByPK", update: true);
            }
            else
            {
                var insertCustomer = new
                {
                    customer.CustomerName,
                    customer.HomeAddress,
                    customer.Email,
                    customer.MobileNo,
                    customer.GSTNO,
                    customer.CityName,
                    customer.PinCode,
                    customer.NetAmount,
                    customer.UserID,
                };
                _sqlHelper.PerformSqlOperation(insertCustomer, "PR_Customer_Insert", insert: true);
            }
            return RedirectToAction("Index");
        }
        return RedirectToAction("AddEditCustomer", customer);
    }

    public IActionResult DeleteCustomer(int customerId)
    {
        // Dictionary<string,object> parameters = new Dictionary<string,object>
        // {
        //     {"@CID",}
        // };
        var deleteObj = new
        {
            customerId
        };
        // _sqlHelper.ExecuteStoredProcedure(, parameters);
        _sqlHelper.PerformSqlOperation(deleteObj, "PR_Customer_DeleteByPK", delete: true);
        return RedirectToAction("Index");
    }
}

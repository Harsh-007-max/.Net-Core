using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class OrderController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    public OrderController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
    }
    // GET
    public IActionResult Index()
    {
        DataTable allOrders = this._sqlHelper.ExecuteStoredProcedure("PR_Oreder_SelectAll");
        return View(allOrders);
    }

    public IActionResult AddEditOrder()
    {
        DataTable userDropdown = _sqlHelper.ExecuteStoredProcedure("PR_User_DropDown");
        List<UserDropDownModel> userDropdownList = new List<UserDropDownModel>();
        foreach (DataRow dataRow in userDropdown.Rows)
        {
            UserDropDownModel userDropDownModel= new UserDropDownModel();
            userDropDownModel.UserID= Convert.ToInt32(dataRow["UserID"]);
            userDropDownModel.UserName= dataRow["UserName"].ToString()!;
            userDropdownList.Add(userDropDownModel);

        }
        DataTable customerDropdown = _sqlHelper.ExecuteStoredProcedure("PR_Customer_DropDown");
        List<CustomerDropDownModel> customerDropdownList = new List<CustomerDropDownModel>();
        foreach (DataRow dataRow in customerDropdown.Rows)
        {
            CustomerDropDownModel customerDropDownModel= new CustomerDropDownModel();
            customerDropDownModel.CustomerID= Convert.ToInt32(dataRow["CustomerID"]);
            customerDropDownModel.CustomerName= dataRow["CustomerName"].ToString()!;
            customerDropdownList.Add(customerDropDownModel);

        }
        ViewBag.UserList=userDropdownList;
        ViewBag.CustomerList=customerDropdownList;
        return View();
    }
    public IActionResult OrderSave(OrderModel order)
    {
        if (ModelState.IsValid)
        {
            return View("Index");
        }
        return View("AddEditOrder");
    }

    public IActionResult DeleteOrder(int orderId)
    {
        Dictionary<string,object> parameters = new Dictionary<string,object>
        {
            {"@OID",orderId}
        };
        _sqlHelper.ExecuteStoredProcedure("PR_Order_DeleteByPK",parameters);
        return RedirectToAction("Index");
    }
}
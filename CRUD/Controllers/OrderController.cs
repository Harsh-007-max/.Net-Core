using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class OrderController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    private FillDropdown _fillDropdown;
    public OrderController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
        _fillDropdown = new FillDropdown();
    }
    // GET
    public IActionResult Index()
    {
        DataTable allOrders = this._sqlHelper.ExecuteStoredProcedure("PR_Oreder_SelectAll")!;
        return View(allOrders);
    }

    public IActionResult AddEditOrder(int? OrderId)
    {
        DataTable userDropdown = _sqlHelper.ExecuteStoredProcedure("PR_User_DropDown")!;
        List<UserDropDownModel> userDropdownList = _fillDropdown.FIllDropDown<UserDropDownModel>(userDropdown);
        DataTable customerDropdown = _sqlHelper.ExecuteStoredProcedure("PR_Customer_DropDown")!;
        List<CustomerDropDownModel> customerDropdownList = _fillDropdown.FIllDropDown<CustomerDropDownModel>(customerDropdown);
        ViewBag.UserList = userDropdownList;
        ViewBag.CustomerList = customerDropdownList;
        OrderModel order = new OrderModel();
        if(OrderId!=null){
          order = _sqlHelper.GetByID<OrderModel>("PR_Oreder_SelectByPK","@OrderID",OrderId??1);
        }
        return View(order);
    }
    public IActionResult OrderSave(OrderModel order)
    {
        if (ModelState.IsValid)
        {
            if (order.OrderID > 0)
            {
              _sqlHelper.PerformSqlOperation<OrderModel>(order,"PR_Order_UpdateByPK",update:true);
            }
            else
            {
                var insertOrder = new
                {
                    order.OrderDate,
                    order.CustomerID,
                    order.PaymentMode,
                    order.TotalAmount,
                    order.ShippingAddress,
                    order.UserID,
                };
                _sqlHelper.PerformSqlOperation(insertOrder,"PR_Order_Insert",insert:true);
            }
            return RedirectToAction("Index");
        }
        return RedirectToAction("AddEditOrder", order);
    }

    public IActionResult DeleteOrder(int orderId)
    {
        // Dictionary<string,object> parameters = new Dictionary<string,object>
        // {
        //     {"@OID",}
        // };
        var deleteObj = new
        {
            orderId
        };
        // _sqlHelper.ExecuteStoredProcedure("PR_Order_DeleteByPK",parameters);
        _sqlHelper.PerformSqlOperation(deleteObj, "PR_Order_DeleteByPK", delete: true);
        return RedirectToAction("Index");
    }
}

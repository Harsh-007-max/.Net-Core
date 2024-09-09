using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class OrderDetailController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    public OrderDetailController(IConfiguration configuration){
        _configuration = configuration;
        String connectionString = this._configuration.GetConnectionString("ConnectionString");
        _sqlHelper = new SqlHelper(connectionString);
    }
    // GET
    public IActionResult Index()
    {
        DataTable allOrderDetails = this._sqlHelper.ExecuteStoredProcedure("PR_OrderDetail_SelectAll");
        return View(allOrderDetails);
    }

    public IActionResult AddEditOrderDetail()
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
        DataTable orderDropdown= _sqlHelper.ExecuteStoredProcedure("PR_Order_DropDown");
        List<OrderDropDownModel> orderDropdownList = new List<OrderDropDownModel>();
        foreach (DataRow dataRow in orderDropdown.Rows)
        {
            OrderDropDownModel orderDropDownModel= new OrderDropDownModel();
            orderDropDownModel.OrderID= Convert.ToInt32(dataRow["OrderID"]);
            orderDropdownList.Add(orderDropDownModel);

        }
        DataTable productDropdown= _sqlHelper.ExecuteStoredProcedure("PR_Product_DropDown");
        List<ProductDropDownModel> productDropdownList = new List<ProductDropDownModel>();
        foreach (DataRow dataRow in productDropdown.Rows)
        {
            ProductDropDownModel productDropDownModel= new ProductDropDownModel();
            productDropDownModel.ProductID= Convert.ToInt32(dataRow["ProductID"]);
            productDropDownModel.ProductName= dataRow["ProductName"].ToString()!;
            productDropdownList.Add(productDropDownModel);
        }
        ViewBag.UserList = userDropdownList;
        ViewBag.OrderList = orderDropdownList;
        ViewBag.ProductList = productDropdownList;
        return View();
    }

    public IActionResult OrderDetailSave(OrderDetailModel orderDetailModel)
    {
        if (ModelState.IsValid)
        {
            return View("Index");
        }
        return View("AddEditOrderDetail");
    }
    public IActionResult DeleteOrderDetail(int orderDetailId)
    {
        Dictionary<string,object> parameters = new Dictionary<string,object>
        {
            {"@OIDI",orderDetailId}
        };
        _sqlHelper.ExecuteStoredProcedure("PR_OrderDetail_DeleteByPK",parameters);
        return RedirectToAction("Index");
    }
}
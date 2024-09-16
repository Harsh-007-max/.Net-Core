using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class OrderDetailController : Controller
{
    #region configuration
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    private FillDropdown _fillDropdown;
    public OrderDetailController(IConfiguration configuration)
    {
        _configuration = configuration;
        String connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
        _fillDropdown = new FillDropdown();
    }
    #endregion
    #region Index
    public IActionResult Index()
    {
        DataTable allOrderDetails = this._sqlHelper.ExecuteStoredProcedure("PR_OrderDetail_SelectAll")!;
        return View(allOrderDetails);
    }
    #endregion
    #region AddEditOrderDetail
    public IActionResult AddEditOrderDetail(int? orderDetailId)
    {
        DataTable userDropdown = _sqlHelper.ExecuteStoredProcedure("PR_User_DropDown")!;
        List<UserDropDownModel> userDropdownList = _fillDropdown.FIllDropDown<UserDropDownModel>(userDropdown);
        DataTable orderDropdown = _sqlHelper.ExecuteStoredProcedure("PR_Order_DropDown")!;
        List<OrderDropDownModel> orderDropdownList = _fillDropdown.FIllDropDown<OrderDropDownModel>(orderDropdown);
        DataTable productDropdown = _sqlHelper.ExecuteStoredProcedure("PR_Product_DropDown")!;
        List<ProductDropDownModel> productDropdownList = _fillDropdown.FIllDropDown<ProductDropDownModel>(productDropdown);
        OrderDetailModel orderDetailModel = new OrderDetailModel();
        ViewBag.Title ="Add OrderDetail";
        if (orderDetailId != null)
        {
            orderDetailModel = _sqlHelper.GetByID<OrderDetailModel>("PR_OrderDetail_SelectByPK", "@OrderDetailID", orderDetailId ?? 1);
            ViewBag.Title ="Update OrderDetail";
        }
        ViewBag.UserList = userDropdownList;
        ViewBag.OrderList = orderDropdownList;
        ViewBag.ProductList = productDropdownList;
        return View(orderDetailModel);
    }
    #endregion
    #region OrderDetailSave
    public IActionResult OrderDetailSave(OrderDetailModel orderDetailModel)
    {
        if (ModelState.IsValid)
        {
            if (orderDetailModel.OrderDetailID > 0)
            {
                _sqlHelper.PerformSqlOperation(orderDetailModel, "PR_OrderDetail_UpdateByPK", update: true);
            }
            else
            {
                var insertOrder = new
                {
                    orderDetailModel.OrderID,
                    orderDetailModel.UserID,
                    orderDetailModel.ProductID,
                    orderDetailModel.TotalAmount,
                    orderDetailModel.Amount,
                    orderDetailModel.Quantity,
                };
                _sqlHelper.PerformSqlOperation(insertOrder, "PR_OrderDetail_Insert", insert: true);
            }
            return RedirectToAction("Index");
        }
        return RedirectToAction("AddEditOrderDetail", orderDetailModel);
    }
    #endregion
    #region DeleteOrderDetail
    public IActionResult DeleteOrderDetail(int orderDetailId)
    {
        var deleteObj = new
        {
            orderDetailId
        };
        _sqlHelper.PerformSqlOperation(deleteObj, "PR_OrderDetail_DeleteByPK", delete: true);
        return RedirectToAction("Index");
    }
    #endregion
}

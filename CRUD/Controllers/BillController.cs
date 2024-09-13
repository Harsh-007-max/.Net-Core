using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class BillController : Controller
{
    #region configuration
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    private FillDropdown _fillDropdown;
    public BillController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
        _fillDropdown = new FillDropdown();
    }
    #endregion
    #region home
    public IActionResult Index()
    {
        DataTable allBills = this._sqlHelper.ExecuteStoredProcedure("PR_Bills_SelectAll")!;
        return View(allBills);
    }
    #endregion

    #region AddEditBill
    public IActionResult AddEditBill(int? BillId)
    {
        DataTable userDropdown = _sqlHelper.ExecuteStoredProcedure("PR_User_DropDown")!;
        List<UserDropDownModel> userDropdownList = _fillDropdown.FIllDropDown<UserDropDownModel>(userDropdown);
        DataTable orderDropdown = _sqlHelper.ExecuteStoredProcedure("PR_Order_DropDown")!;
        List<OrderDropDownModel> orderDropDownList = _fillDropdown.FIllDropDown<OrderDropDownModel>(orderDropdown);
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        BillsModel billsModel = new BillsModel();
        if (BillId != null)
        {
            billsModel = _sqlHelper.GetByID<BillsModel>("PR_Bills_SelectByPK", "@BillId", BillId ?? 1);
        }
        ViewBag.UserList = userDropdownList;
        ViewBag.OrderList = orderDropDownList;
        return View(billsModel);
    }
    #endregion
    #region save
    public IActionResult SaveBill(BillsModel bill)
    {
        if (ModelState.IsValid)
        {
            if (bill.BillId > 0)
            {
                _sqlHelper.PerformSqlOperation(bill, "PR_Bills_UpdateByPK", update: true);
            }
            else
            {
                var insertBill = new
                {
                    bill.BillNumber,
                    bill.BillDate,
                    bill.TotalAmount,
                    bill.NetAmount,
                    bill.Discount,
                    bill.OrderID,
                    bill.UserID
                };
                _sqlHelper.PerformSqlOperation(insertBill, "PR_Bills_Insert", insert: true);
            }
            return RedirectToAction("Index");
        }
        return RedirectToAction("AddEditBill", bill);
    }
    #endregion

    #region delete
    public IActionResult DeleteBill(int billId)
    {
        var deleteObj = new
        {
            billId
        };
        _sqlHelper.PerformSqlOperation(deleteObj, "PR_Bills_DeleteByPK", delete: true);
        return RedirectToAction("Index");
    }
    #endregion
}

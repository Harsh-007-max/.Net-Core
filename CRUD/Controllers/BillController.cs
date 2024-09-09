using System.Data;
using System.Data.SqlClient;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class BillController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    
    public BillController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
    }
    // GET
    public IActionResult Index()
    {
        DataTable allBills = this._sqlHelper.ExecuteStoredProcedure("PR_Bills_SelectAll");
        return View(allBills);
    }

    public IActionResult AddEditBill(int? BillId)
    {
        DataTable userDropdown = _sqlHelper.ExecuteStoredProcedure("PR_User_DropDown");
        List<UserDropDownModel> userDropdownList = new List<UserDropDownModel>();
        foreach (DataRow dataRow in userDropdown.Rows)
        {
            UserDropDownModel userDropDownModel= new UserDropDownModel();
            userDropDownModel.UserID= Convert.ToInt32(dataRow["UserID"]);
            userDropdownList.Add(userDropDownModel);

        }
        DataTable orderDropdown= _sqlHelper.ExecuteStoredProcedure("PR_Order_DropDown");
        List<OrderDropDownModel> orderDropDownList= new List<OrderDropDownModel>();
        foreach (DataRow dataRow in orderDropdown.Rows)
        {
            OrderDropDownModel orderDropDownModel= new OrderDropDownModel();
            orderDropDownModel.OrderID= Convert.ToInt32(dataRow["OrderID"]);
            orderDropDownList.Add(orderDropDownModel);
        }
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "PR_Bills_SelectByPK";
        command.Parameters.Add("@BID",SqlDbType.Int).Value=BillId;
        SqlDataReader reader =  command.ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load(reader);
        BillsModel billsModel = new BillsModel();
        foreach (DataRow dataRow in dataTable.Rows)
        {
            billsModel.OrderID = Convert.ToInt32(dataRow["OrderID"]);
            billsModel.UserID = Convert.ToInt32(dataRow["UserID"]);
            billsModel.BillDate = Convert.ToDateTime(dataRow["BillDate"]);
            billsModel.BillNumber = dataRow["BillNumber"].ToString();
            billsModel.Discount = Convert.ToDecimal(dataRow["Discount"]);
            billsModel.NetAmount = Convert.ToDecimal(dataRow["NetAmount"]);
            billsModel.TotalAmount = Convert.ToDecimal(dataRow["TotalAmount"]);
        }
        ViewBag.UserList = userDropdownList;
        ViewBag.OrderList=orderDropDownList;
        return View(billsModel);
    }

    public IActionResult SaveBill(BillsModel bill)
    {
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        if (ModelState.IsValid)
        {
            if (bill.BillId >0)
            {
                command.CommandText = "PR_Bills_UpdateByPK";
                command.Parameters.AddWithValue("@BID", bill.BillId);
            }
            else
            {
                command.CommandText = "PR_Bills_Insert";
            }

            command.Parameters.AddWithValue("@BillNumber", bill.BillNumber);
            command.Parameters.AddWithValue("@UserID",bill.UserID);
            command.Parameters.AddWithValue("@NetAmount",bill.NetAmount);
            command.Parameters.AddWithValue("@Discount",bill.Discount);
            command.Parameters.AddWithValue("@TotalAmount",bill.TotalAmount);
            command.Parameters.AddWithValue("@BillDate",bill.BillDate);
            command.Parameters.AddWithValue("@OrderID",bill.OrderID);
            command.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
        return RedirectToAction("AddEditBill",bill);
    }

    public IActionResult DeleteBill(int billId)
    {
        
        Dictionary<string,object> data = new Dictionary<string, object>
        {
            {"@BID",billId}
        };
        _sqlHelper.ExecuteStoredProcedure("PR_Bills_DeleteByPK",data);
        return RedirectToAction("Index");
    }
}
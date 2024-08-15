using NiceAdmin2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
namespace NiceAdmin2.Controllers;
using NiceAdmin2.Models;

public class OrderDetails : Controller
{
    private IConfiguration configuration;

    public OrderDetails(IConfiguration _configuration)
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
        command.CommandText = "PR_OrderDetail_SelectAll";
        SqlDataReader reader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load(reader);
        return View(table);
    }

    public IActionResult DeleteOrderDetail(int OrderDetailsID)
    {
        string connectionString = this.configuration.GetConnectionString("ConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "PR_OrderDetail_DeleteByPK";
        command.Parameters.Add("@OIDI", SqlDbType.Int).Value =OrderDetailsID;
        command.ExecuteNonQuery();
        return View("Index");
    }
    public IActionResult AddEditOrderDetails()
    {
        string connectionString = this.configuration.GetConnectionString("ConnectionString");
        SqlConnection connection1 = new SqlConnection(connectionString);
        connection1.Open();
        SqlCommand command1 = connection1.CreateCommand();
        command1.CommandType = System.Data.CommandType.StoredProcedure;
        command1.CommandText = "PR_User_DropDown";
        SqlDataReader reader1 = command1.ExecuteReader();
        DataTable dataTable1 = new DataTable();
        dataTable1.Load(reader1);
        List<UserDropDownModel> userList= new List<UserDropDownModel>();
        foreach (DataRow dataRow in dataTable1.Rows)
        {
            UserDropDownModel userDropDownModel= new UserDropDownModel();
            userDropDownModel.UserID= Convert.ToInt32(dataRow["UserID"]);
            userDropDownModel.UserName= dataRow["UserName"].ToString();
            userList.Add(userDropDownModel);
        }
        command1.CommandText = "PR_Order_DropDown";
        SqlDataReader reader2 = command1.ExecuteReader();
        DataTable dataTable2 = new DataTable();
        dataTable2.Load(reader2);
        List<OrderDropDownModel> orderList= new List<OrderDropDownModel>();
        foreach (DataRow dataRow in dataTable2.Rows)
        {
            OrderDropDownModel orderDropDownModel= new OrderDropDownModel();
            orderDropDownModel.OrderID= Convert.ToInt32(dataRow["OrderID"]);
            orderList.Add(orderDropDownModel);
        }
        command1.CommandText = "PR_Product_DropDown";
        SqlDataReader reader3 = command1.ExecuteReader();
        DataTable dataTable3 = new DataTable();
        dataTable3.Load(reader3);
        List<ProductDropDownModel> productList= new List<ProductDropDownModel>();
        foreach (DataRow dataRow in dataTable3.Rows)
        {
            ProductDropDownModel productDropDownModel= new ProductDropDownModel();
            productDropDownModel.ProductID= Convert.ToInt32(dataRow["ProductID"]);
            productDropDownModel.ProductName= dataRow["ProductName"].ToString();
            productList.Add(productDropDownModel);
        }
        ViewBag.UserList=userList;
        ViewBag.OrderList=orderList;
        ViewBag.ProductList=productList;
        return View();
    }

    public IActionResult Save(OrderDetailModel orderDetail)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Index",orderDetail);
        }
        return View("AddEditOrderDetails",orderDetail);
    }
}
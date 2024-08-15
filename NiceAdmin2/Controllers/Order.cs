using Microsoft.AspNetCore.Mvc;
using NiceAdmin2.Models;
using System.Data.SqlClient;
using System.Data;

namespace NiceAdmin2.Controllers;

public class Order : Controller
{
    private IConfiguration configuration;

    public Order(IConfiguration _configuration)
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
        command.CommandText = "PR_Oreder_SelectAll";
        SqlDataReader reader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load(reader);
        return View("Order",table);
    }

    public IActionResult AddEditOrder()
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
        command1.CommandText = "PR_Customer_DropDown";
        SqlDataReader reader2 = command1.ExecuteReader();
        DataTable dataTable2 = new DataTable();
        dataTable2.Load(reader2);
        List<CustomerDropDownModel> customerList= new List<CustomerDropDownModel>();
        foreach (DataRow dataRow in dataTable2.Rows)
        {
            CustomerDropDownModel customerDropDownModel= new CustomerDropDownModel ();
            customerDropDownModel.CustomerID= Convert.ToInt32(dataRow["CustomerID"]);
            customerDropDownModel.CustomerName= dataRow["CustomerName"].ToString();
            customerList.Add(customerDropDownModel);
        }
        ViewBag.UserList=userList;
        ViewBag.CustomerList=customerList;
        return View("AddEditOrder");
    }

    public IActionResult DeleteOrder(int OrderID)
    {
        string connectionString = this.configuration.GetConnectionString("ConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "PR_Order_DeleteByPK";
        command.Parameters.Add("@OID", SqlDbType.Int).Value =OrderID;
        command.ExecuteNonQuery();
        return RedirectToAction("Index");
    }

    public IActionResult Save(OrderModel order)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("Order", order);
        }
        return View("AddEditOrder", order);
    }
}
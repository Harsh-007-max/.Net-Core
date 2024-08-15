using NiceAdmin2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
namespace NiceAdmin2.Controllers;

public class ProductController : Controller
{
    private IConfiguration configuration;

    public ProductController(IConfiguration _configuration)
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
        command.CommandText = "PR_Product_SelectAll";
        SqlDataReader reader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load(reader);
        return View("Product",table);
        // return View("Product",ProductList);
    }

    public IActionResult DeleteProduct(int ProductID)
    {
        string connectionString = this.configuration.GetConnectionString("ConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "PR_Procedure_DeleteByPK";
        command.Parameters.Add("@PID", SqlDbType.Int).Value = ProductID;
        command.ExecuteNonQuery();
        return RedirectToAction("Index");
    }

    public IActionResult AddEditProduct()
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
        ViewBag.UserList=userList;
        if (ModelState.IsValid)
        {
            return View();
        }
        return View("AddEditProduct");
    }

    public IActionResult Save(ProductModel product)
    {
        if (ModelState.IsValid)
        {
            return View("Index",product);
        }

        return View("AddEditProduct",product);
    }
}
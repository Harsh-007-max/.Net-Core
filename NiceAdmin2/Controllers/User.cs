using NiceAdmin2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace NiceAdmin2.Controllers;
using NiceAdmin2.Models;

public class User : Controller
{
    private IConfiguration configuration;

    public User(IConfiguration _configuration)
    {
        configuration = _configuration;
    }
    // GET
    public IActionResult Index(UserModel? user)
    {
        string connectionString = this.configuration.GetConnectionString("ConnectionString");
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = "PR_User_SelectAll";
        SqlDataReader reader = command.ExecuteReader();
        DataTable table = new DataTable();
        table.Load(reader);
        return View("User",table);
    }

    public IActionResult AddEditUser()
    {
        return View();
    }

    public IActionResult Save(UserModel user)
    {
        
        if (ModelState.IsValid)
        {
            UserModel newUser = new UserModel{UserID=Convert.ToInt32(user.UserID),UserName = user.UserName,Email = user.Email,Password = user.Password,MobileNo = user.MobileNo,Address = user.Address, IsActive =Convert.ToBoolean(user.IsActive)};
            return RedirectToAction("Index",newUser);
        }

        return View("AddEditUser",user);
    }
}
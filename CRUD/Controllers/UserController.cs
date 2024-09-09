using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class UserController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    public UserController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString");
        _sqlHelper = new SqlHelper(connectionString);
    }
    // GET
    public IActionResult Index()
    {
        DataTable allUsers = _sqlHelper.ExecuteStoredProcedure("PR_User_SelectAll");
        return View(allUsers);
    }

    public IActionResult AddEditUser()
    {
        return View();
    }

    public IActionResult UserSave(UserModel user)
    {
        if (ModelState.IsValid)
        {
            return View("Index");
        }

        return View("AddEditUser");
    }
    public IActionResult DeleteUser(int UserID)
    {
        Dictionary<string,object> data = new Dictionary<string, object>
        {
            {"@UID",UserID}
        };
        _sqlHelper.ExecuteStoredProcedure("PR_User_DeleteByPK",data);
        return RedirectToAction("Index");
    }
}
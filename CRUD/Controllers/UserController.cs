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
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
    }
    // GET
    public IActionResult Index()
    {
        DataTable allUsers = _sqlHelper.ExecuteStoredProcedure("PR_User_SelectAll")!;
        return View(allUsers);
    }

    public IActionResult AddEditUser(int? UserID)
    {
        UserModel user = new UserModel();
        if (UserID != null)
        {
            user = _sqlHelper.GetByID<UserModel>("PR_User_SelectByPK", "@UserID", UserID ?? 1);
        }
        return View(user);
    }

    public IActionResult UserSave(UserModel user)
    {
        if (ModelState.IsValid)
        {
            if (user.UserID > 0)
            {
                _sqlHelper.PerformSqlOperation<UserModel>(user, "PR_User_UpdateByPK", update: true);
            }
            else
            {
                var insertUser = new
                {
                    user.UserName,
                    user.Email,
                    user.Password,
                    user.MobileNo,
                    user.Address,
                    user.IsActive,
                };
                _sqlHelper.PerformSqlOperation(insertUser, "PR_User_Insert", insert: true);
            }
            return RedirectToAction("Index");
        }

        return View("AddEditUser", user);
    }
    public IActionResult DeleteUser(int UserID)
    {
        var deleteObj = new
        {
            UserID
        };
        _sqlHelper.PerformSqlOperation(deleteObj, "PR_User_DeleteByPK", delete: true);
        return RedirectToAction("Index");
    }
}

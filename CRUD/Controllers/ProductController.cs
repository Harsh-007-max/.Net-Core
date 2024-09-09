using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class ProductController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    public ProductController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
    }
    // GET
    public IActionResult Index()
    {
        DataTable allProducts = _sqlHelper.ExecuteStoredProcedure("PR_Product_SelectAll");
        return View(allProducts);
    }

    public IActionResult AddEditProduct()
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
        ViewBag.UserList = userDropdownList;
        return View();
    }

    public IActionResult ProductSave(ProductModel product)
    {
        if (ModelState.IsValid)
        {
            return View("Index");
        }
        return View("AddEditProduct");
    }

    public IActionResult DeleteProduct(int productID)
    {
        Dictionary<string,object> data = new Dictionary<string, object>
        {
            {"@PID",productID}
        };
        _sqlHelper.ExecuteStoredProcedure("PR_Procedure_DeleteByPK",data);
        return RedirectToAction("Index");
    }
}
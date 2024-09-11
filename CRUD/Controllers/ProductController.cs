using System.Data;
using CRUD.Helpers;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers;

public class ProductController : Controller
{
    private IConfiguration _configuration;
    private SqlHelper _sqlHelper;
    private FillDropdown _fillDropdown;
    public ProductController(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionString = this._configuration.GetConnectionString("ConnectionString")!;
        _sqlHelper = new SqlHelper(connectionString);
        _fillDropdown = new FillDropdown();
    }
    // GET
    public IActionResult Index()
    {
        DataTable allProducts = _sqlHelper.ExecuteStoredProcedure("PR_Product_SelectAll")!;
        return View(allProducts);
    }

    public IActionResult AddEditProduct(int? ProductID)
    {
        DataTable userDropdown = _sqlHelper.ExecuteStoredProcedure("PR_User_DropDown")!;
        List<UserDropDownModel> userDropdownList = _fillDropdown.FIllDropDown<UserDropDownModel>(userDropdown);
        ViewBag.UserList = userDropdownList;
        ProductModel product = new ProductModel();
        if (ProductID != null)
        {
            product = _sqlHelper.GetByID<ProductModel>("PR_Product_SelectByPK", "@ProductID", ProductID ?? 1);
        }
        return View(product);
    }

    public IActionResult ProductSave(ProductModel product)
    {
        if (ModelState.IsValid)
        {
            if (product.ProductID > 0)
            {
                _sqlHelper.PerformSqlOperation<ProductModel>(product, "PR_Product_UpdateByPK", update: true);
            }
            else
            {
                var insertProduct = new
                {
                    product.ProductName,
                    product.ProductPrice,
                    product.ProductCode,
                    product.Description,
                    product.UserID,

                };
                _sqlHelper.PerformSqlOperation(insertProduct, "PR_Product_Insert", insert: true);
            }
            return RedirectToAction("Index");
        }
        return RedirectToAction("AddEditProduct", product);
    }

    public IActionResult DeleteProduct(int productID)
    {
        var deleteObj = new
        {
            productID
        };
        _sqlHelper.PerformSqlOperation(deleteObj, "PR_Procedure_DeleteByPK", delete: true);
        return RedirectToAction("Index");
    }
}

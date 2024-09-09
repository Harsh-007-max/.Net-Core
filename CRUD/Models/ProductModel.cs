using System.ComponentModel.DataAnnotations;
namespace CRUD.Models;

public class ProductModel
{
    [Required]
    [Display(Name = "Product ID")]
    [Range(1, int.MaxValue)]
    public int ProductID { get; set; }
    
    [Required]
    [Display(Name = "Product Name")]
    public String ProductName { get; set; }
    
    [Required]
    [Display(Name = "Product Price")]
    [Range(0, int.MaxValue)]
    public double ProductPrice { get; set; }
    
    [Required]
    [Display(Name = "Product Code")]
    public String ProductCode { get; set; }
    
    [Required]
    [Display(Name = "Product Description")]
    public String Description { get; set; }
    
    [Required]
    [Display(Name = "User ID")]
    [Range(1, int.MaxValue)]
    public int UserID { get; set; }
}
public class ProductDropDownModel
{
    [Display(Name = "Product ID")]
    public int ProductID { get; set; }
    
    [Display(Name = "Product Name")]
    public String ProductName { get; set; }
}
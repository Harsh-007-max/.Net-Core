using System.ComponentModel.DataAnnotations;
namespace CRUD.Models;

public class OrderModel
{
    [Required]
    [Display(Name = "Order ID")]
    [Range(1, int.MaxValue)]
    public int OrderID { get; set; }
    
    [Required]
    [Display(Name = "Order Date")]
    public DateTime OrderDate { get; set; }
    
    [Required]
    [Display(Name = "Customer ID")]
    [Range(1, int.MaxValue)]
    public int CustomerID { get; set; }
    
    [Display(Name = "Payment Method")]
    public String PaymentMode { get; set; }
    
    [Display(Name = "Total Amount")]
    [Range(1, int.MaxValue)]
    public double TotalAmount { get; set; }
    
    [Required]
    [Display(Name = "Shipping Address")]
    public String ShippingAddress { get; set; }
    
    [Required]
    [Display(Name = "User ID")]
    [Range(1, int.MaxValue)]
    public int UserID { get; set; }
}

public class OrderDropDownModel
{
    [Display(Name = "Order ID")]
    public int OrderID { get; set; }
    
}

using System.ComponentModel.DataAnnotations;
namespace CRUD.Models;

public class OrderDetailModel
{
    [Required]
    [Display(Name = "Order Detail ID")]
    [Range(0, int.MaxValue)]
    public int OrderDetailID { get; set; }
    
    [Required]
    [Display(Name = "Order ID")]
    [Range(1, int.MaxValue)]
    public int OrderID { get; set; }
    
    [Required]
    [Display(Name = "Product ID")]
    [Range(1, int.MaxValue)]
    public int ProductID { get; set; }
    
    [Required]
    [Display(Name = "Quantity")]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    [Display(Name = "Amount")]
    public decimal Amount { get; set; }
    
    [Required]
    [Range(0, int.MaxValue)]
    [Display(Name = "Total Amount")]
    public decimal TotalAmount { get; set; }
    
    [Required]
    [Display(Name = "User ID")]
    [Range(1, int.MaxValue)]
    public int UserID { get; set; } 
}

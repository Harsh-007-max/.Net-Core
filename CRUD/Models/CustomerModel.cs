using System.ComponentModel.DataAnnotations;
namespace CRUD.Models;

public class CustomerModel
{
    [Required]
    [Display(Name = "Customer ID")]
    [Range(0, int.MaxValue)]
    public int CustomerID { get; set; }
    
    [Required]
    [Display(Name = "Customer Name")]
    public String? CustomerName { get; set; }
    
    [Required]
    [Display(Name = "Home Address")]
    public String? HomeAddress { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public String? Email { get; set; }
    
    [Required]
    [MinLength(10)]
    [MaxLength(10)]
    [Display(Name = "Mobile Number")]
    public String? MobileNo { get; set; }
    
    [Required]
    [Display(Name = "GST Number")]
    public String? GSTNO { get; set; }
    
    [Required]
    [Display(Name = "City Name")]
    public String? CityName { get; set; }
    
    [Required]
    [Display(Name = "Pin Code")]
    public String? PinCode { get; set; }
    
    [Required]
    [Display(Name = "Net Amount")]
    public decimal NetAmount { get; set; }
    
    [Required]
    [Display(Name = "User ID")]
    public int UserID { get; set; }
}
public class CustomerDropDownModel
{
    [Display(Name = "Customer ID")]
    public int CustomerID { get; set; }
    
    [Display(Name = "Customer Name")]
    public String? CustomerName { get; set; }
}

using System.ComponentModel.DataAnnotations;
namespace CRUD.Models;

public class CustomerModel
{
    [Required]
    [Display(Name = "Customer ID")]
    public int CustomerId { get; set; }
    
    [Required]
    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }
    
    [Required]
    [Display(Name = "Home Address")]
    public string HomeAddress { get; set; }
    
    [Required]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string Email { get; set; }
    
    [Required]
    [MinLength(10)]
    [MaxLength(10)]
    [Display(Name = "Mobile Number")]
    public string MobileNo { get; set; }
    
    [Required]
    [Display(Name = "GST Number")]
    public string GSTNO { get; set; }
    
    [Required]
    [Display(Name = "City Name")]
    public string CityName { get; set; }
    
    [Required]
    [Display(Name = "Pin Code")]
    public string PinCode { get; set; }
    
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
    public String CustomerName { get; set; }
}

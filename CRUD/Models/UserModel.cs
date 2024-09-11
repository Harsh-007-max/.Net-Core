using System.ComponentModel.DataAnnotations;
namespace CRUD.Models;

public class UserModel
{
    [Required]
    [Display(Name = "User ID")]
    [Range(0, int.MaxValue)]
    public int UserID { get; set; }
    
    [Required]
    [Display(Name = "User Name")]
    public required String UserName { get; set; }
    
    [Required]
    [Display(Name = "Email")]
    [EmailAddress]
    public required String Email { get; set; }
    
    [Required]
    [Display(Name = "Password")]
    public required String Password { get; set; }
    
    [Required]
    [Display(Name = "Mobile Number")]
    [MinLength(10)]
    [MaxLength(10)]
    public required String MobileNo { get; set; }
    
    [Required]
    [Display(Name = "Address")]
    public required String Address { get; set; }
    
    [Required]
    [Display(Name = "Is Active User")]
    public Boolean IsActive { get; set; }
}
public class UserDropDownModel
{

    [Display(Name = "User ID")]
    public int UserID { get; set; }
    
    [Display(Name = "User Name")]
    public required String UserName { get; set; }
}

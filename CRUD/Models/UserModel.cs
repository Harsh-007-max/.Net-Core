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
    public String? UserName { get; set; }
    
    [Required]
    [Display(Name = "Email")]
    [EmailAddress]
    public String? Email { get; set; }
    
    [Required]
    [Display(Name = "Password")]
    public String? Password { get; set; }
    
    [Required]
    [Display(Name = "Mobile Number")]
    [MinLength(10)]
    [MaxLength(10)]
    public String? MobileNo { get; set; }
    
    [Required]
    [Display(Name = "Address")]
    public String? Address { get; set; }
    
    [Required]
    [Display(Name = "Is Active User")]
    public Boolean IsActive { get; set; }
}
public class UserDropDownModel
{

    [Display(Name = "User ID")]
    public int UserID { get; set; }
    
    [Display(Name = "User Name")]
    public String? UserName { get; set; }
}

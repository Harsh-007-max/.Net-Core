using System.ComponentModel.DataAnnotations;

namespace CRUD.Models;

public class BillsModel
{
    [Display(Name = "Bill Id")]
    public int? BillId { get; set; }

    [Required]
    [Display(Name = "Bill Number")]
    public String? BillNumber { get; set; }

    [Required]
    [Display(Name = "Bill Date")]
    [DataType(DataType.DateTime)]
    public DateTime BillDate { get; set; }

    [Required]
    [Display(Name = "Order ID")]
    public int OrderID { get; set; }

    [Required]
    [Display(Name = "Total Amount")]
    public decimal TotalAmount { get; set; }

    [Display(Name = "Discount")]
    public decimal Discount { get; set; }

    [Required]
    [Display(Name = "Net Amount")]
    public decimal NetAmount { get; set; }

    [Required]
    [Display(Name = "User ID")]
    public int UserID { get; set; }
}

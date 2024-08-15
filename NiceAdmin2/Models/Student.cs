using System.ComponentModel.DataAnnotations;

namespace NiceAdmin2.Models;

public class Student
{
    public int StudentID { get; set; }
    [Required(ErrorMessage = "This field is Compulsory")]
    [Display(Name="Student Name is Compulsory")]
    public String StudentName { get; set; }
    public String? EnrollmentNo { get;set; }
    public String? Password{ get; set; }
    public int? RollNo { get; set; }
    public int CurrentSemester { get; set; }
    [Required]
    // [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public String EmailInstitute { get; set; }
    [Required]
    // [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public String? EmailPersonal { get; set; }
    
    public int? ContactNo { get; set; }
    public int CastID { get; set; }
    public int CityID { get; set; }
    public String? Remarks { get; set; }
}
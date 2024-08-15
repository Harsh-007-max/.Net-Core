namespace Class_Code.Models;

public class Student
{
    public int StudentID { get; set; }
    public String StudentName { get; set; }
    public String? EnrollmentNo { get;set; }
    public String? Password{ get; set; }
    public int? RollNo { get; set; }
    public int CurrentSemester { get; set; }
    public String EmailInstitute { get; set; }
    public String? EmailPersonal { get; set; }
    public int? ContactNo { get; set; }
    public int CastID { get; set; }
    public int CityID { get; set; }
    public String? Remarks { get; set; }
}
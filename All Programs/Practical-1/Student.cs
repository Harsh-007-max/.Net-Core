namespace All_Programs.Practical_1;

public class Student
{
    public int Enrollment_No, Semester;
    public double SPI, CPI;
    public string Name;
    public Student(int Enrollment_no,int Semester,double SPI,double CPI,string Name)
    {
        this.Enrollment_No = Enrollment_no;
        this.Semester = Semester;
        this.SPI =SPI;
        this.CPI =CPI;
        this.Name =Name;
    }
    public void DisplayStudentDetails()
    {
        Console.WriteLine(Enrollment_No);
        Console.WriteLine(Name);
        Console.WriteLine(Semester);
        Console.WriteLine(SPI);
        Console.WriteLine(CPI);
    }

}
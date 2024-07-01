namespace All_Programs.Practical_4;
using System.Collections;

public class Prog_1
{
    public void prog1()
    {
        ArrayList StudentName= new ArrayList();
        StudentName.Add("Bhagyesh");
        StudentName.Add("Kunal");
        StudentName.Add("Harsh");
        StudentName.Add("Karan");
        StudentName.Add("Bhavin");
        Console.WriteLine(StudentName[0]);
        StudentName.RemoveAt(0);
        Console.WriteLine(StudentName[0]);
        StudentName.RemoveRange(2,2);
        StudentName.Clear();
    }
}

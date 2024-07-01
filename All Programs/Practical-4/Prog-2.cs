namespace All_Programs.Practical_4;
using System.Collections;
public class Prog_2
{
    public void start()
    {
        List<string> Students = new List<string>();
        Students.Add("Bhagyesh");
        Students.Add("Kunal");
        Students.Add("Harsh");
        Students.Add("Karan");
        Students.Add("Bhavin");
        Students.Remove("Bhagyesh");
        Students.RemoveRange(2,2);
        Students.Clear();
    }
}

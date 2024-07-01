namespace All_Programs.Practical_3;
public class Prog_1
{
    public void Add(int a, int b) {
        Console.WriteLine("Addition of two numbers: "+(a+b));
    }

    public void Add(double a, double b)
    {
        Console.WriteLine("Addition of double two numbers: "+(a+b));
    }
    public void start()
    {
        this.Add(1,2);
        this.Add(1.1,2.2);
    }
}

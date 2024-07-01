namespace All_Programs.Practical_2;

public abstract class Sum
{
    public abstract void SumOfTwo(int a, int b);
    public abstract void SumOfThree(int a, int b,int c);
}
public class Calculate:Sum{
    public override void SumOfTwo(int a, int b)
    {
        int c = a + b;
        Console.WriteLine("sum of two numbers is: "+c);
    }
    public override void SumOfThree(int a, int b, int c)
    {
        int d = a + b + c;
        Console.WriteLine("sum of three numbers is: "+d);
    }
}
public class Prog_3
{
    public void start()
    {
        Calculate c = new Calculate();
        c.SumOfThree(1,2,3);
        c.SumOfTwo(4,5);
    }
}

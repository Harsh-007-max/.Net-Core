namespace All_Programs.Practical_3;

public class Prog_2
{
    public void method1(int a)
    {
        Console.WriteLine("int a = "+a);
    }

    public void method1(int a, int b)
    {
        Console.WriteLine("Int a+b = "+(a+b));
    }
    public void start()
    {
        this.method1(1);   
        this.method1(1,2);   
    }
}

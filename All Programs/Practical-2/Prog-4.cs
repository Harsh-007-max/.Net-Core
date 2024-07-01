namespace All_Programs.Practical_2;

interface ICalculate
{
    public void Addition();
    public void Subtraction();
}

public class Result:ICalculate
{
    protected int a, b,c;
    public Result(int a, int b)
    {
        this.a = a;
        this.b = b;
    }
    public void Addition()
    {
        c = a + b;
        Console.WriteLine("Addition of two numbers is:"+c);
    }

    public void Subtraction()
    {
        c = a - b;
        Console.WriteLine("Subtraction of two numbers is:"+c);
    }
}
public class Prog_4
{
    public void start()
    {
        Result r = new Result(1,2);
        r.Addition();
        r.Subtraction();
    }
}

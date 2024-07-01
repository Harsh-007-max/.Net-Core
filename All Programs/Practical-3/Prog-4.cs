namespace All_Programs.Practical_3;

public class Prog_4
{
    public delegate int facDel(int i);

    public void start()
    {
        facDel factoDeligate = factorial;
        Console.WriteLine("Factorial is:"+factoDeligate(5));
    }

    static int factorial(int n)
    {
        if (n <= 1)
        {
            return 1;
        }
        else
        {
            return n * factorial(n - 1);
        }
    }
}

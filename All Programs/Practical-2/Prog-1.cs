namespace All_Programs.Practical_2;

public class Prog_1
{
    public void start()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c;
        try
        {
            c = a / b;
            Console.WriteLine("Division of {0}/{1} = {3}",a,b,c);
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine("Divide by zero: "+e);
        }
    }
}
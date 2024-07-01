namespace All_Programs.Practical_2;

public class Prog_8
{
    public void start()
    {
        Console.WriteLine("Enter a number: ");
        int num = Convert.ToInt32(Console.ReadLine());
        if (num % 2 != 0)
        {
            throw new Exception("Number is not even!");
        }
        else
        {
            Console.WriteLine("Number is even");
        }
    }
}

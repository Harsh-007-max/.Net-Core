namespace All_Programs.Practical_2;

public class Prog_2
{
    public void start()
    {
        int[] numberArray = new int[5];
        for (int i = 0; i < numberArray.Length; i++) {
            numberArray[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine("Values are:");
        try
        {
            for (int i = 0; i <= numberArray.Length; i++)
            {
                Console.WriteLine(numberArray[i]);
            }
        }
        catch (IndexOutOfRangeException ie)
        {
            Console.WriteLine("-----------------------Index Out of Range exception-----------------------------");
        }
    }

}
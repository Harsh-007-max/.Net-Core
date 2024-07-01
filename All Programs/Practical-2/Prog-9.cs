namespace All_Programs.Practical_2;

public class Prog_9
{
    public void start()
    {
        Console.WriteLine("Enter a string");
        string str = Console.ReadLine();
        string longest = "";
        foreach (var word in str.Split(" "))
        {
            longest = longest.Length < word.Length ? word : longest;
        }
        Console.WriteLine("Longest word is: "+longest);
    }
}

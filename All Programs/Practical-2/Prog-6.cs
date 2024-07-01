namespace All_Programs.Practical_2;
public class Prog_6
{
    public void start()
    {
        string str = Console.ReadLine();
        string output = "";
        for (int i = 0; i < str.Length; i++)
        {
            output += char.IsLower(Convert.ToChar(str[i]))
                ? Convert.ToString(str[i]).ToUpper()
                : Convert.ToString(str[i]).ToLower();
        }
        Console.WriteLine("Output is: "+output);
    }
}

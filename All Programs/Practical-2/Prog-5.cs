namespace All_Programs.Practical_2;
public class Prog_5
{
    public void start()
    {
        
        string name = "darshan";
        string name1 = "university";
        int len = name.Length;
        
        Console.WriteLine("Upper case: "+name.ToUpper());
        Console.WriteLine("Lower case: "+name.ToLower());
        Console.WriteLine("Concat: "+string.Concat(name+" ",name1));
        Console.WriteLine("Equals: "+name.Equals(name1));
        Console.WriteLine("This is the \"String\" class.");
        Console.WriteLine("Contains: "+name.Contains("d"));
        Console.WriteLine("Insert: "+name.Insert(0,"Hello "));
        Console.WriteLine("Substring: "+name.Substring(0,5));
        Console.WriteLine("Compare: "+string.Compare(name,name1));
        Console.WriteLine("Split: ");
        foreach (var value in "D A R S H A N".Split(" ")) {
            Console.WriteLine(value);
        }
        Console.WriteLine("LastIndexOf: "+name.LastIndexOf("a"));
        Console.WriteLine("IndexOf: "+name.IndexOf("a"));
        Console.WriteLine("Length: "+name.Length);
        Console.WriteLine("Replace: "+name.Replace("a","@"));
        Console.WriteLine("Clone: "+name.Clone());
        Console.WriteLine("CompareTo: "+name.CompareTo(name1));
        Console.WriteLine("EndsWith: "+name.EndsWith("n"));
        Console.WriteLine("StartsWith: "+name.StartsWith("d"));
        Console.WriteLine("          name               ".Trim());
    }
}

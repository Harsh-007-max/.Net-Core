namespace All_Programs.Practical_3;

internal class RBI
{
    public void calculateInterest()
    {
        Console.WriteLine("Calculate Interest"+this.GetType().Name);
    }
}

internal class HDFC : RBI
{
    public void calculateInterest()
    {
        Console.WriteLine("Calculate Interest "+this.GetType().Name);
    }    
}
internal class SBI : RBI
{
    public void calculateInterest()
    {
        Console.WriteLine("Calculate Interest "+this.GetType().Name);
    }    
}

internal class ICICI : RBI
{
    public void calculateInterest()
    {
        Console.WriteLine("Calculate Interest "+this.GetType().Name);
    }    
}
public class Prog_3
{
    public void start()
    {
        new HDFC().calculateInterest();
        new SBI().calculateInterest();
        new ICICI().calculateInterest();
        
    }
}

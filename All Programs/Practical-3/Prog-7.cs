namespace All_Programs.Practical_3;

public  delegate void del1();
public class TrafficSignal
{
    public static void Yellow()
    {
        Console.WriteLine("Yellow Light Sign to Get Ready");
    }
    public static void Green()
    {
        Console.WriteLine("Green Light Sign To Go");
    }
    public static void Red()
    {
        Console.WriteLine("Red Light Sign To Stop");
    }
}

public class Prog_7
{
    public void start()
    {
        del1 trafficDeligation = TrafficSignal.Yellow;
        trafficDeligation += TrafficSignal.Green;
        trafficDeligation += TrafficSignal.Red;
        trafficDeligation();
    }   
}

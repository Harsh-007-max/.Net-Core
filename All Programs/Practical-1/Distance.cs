namespace All_Programs.Practical_1;

public class Distance
{
    double dist1, dist2,dist3;
    public Distance(double dist1,double dist2)
    {
        this.dist1 = dist1;
        this.dist2 = dist2;
    }
    public void DisplayAddition()
    {
        this.dist3 = this.dist1 + this.dist2;
        Console.WriteLine("The total distance of dist1 and dist2 is: "+this.dist3);
    }

}
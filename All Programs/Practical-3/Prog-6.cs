namespace All_Programs.Practical_3;

public class FindArea
{
    public void findArea(double side) => Console.WriteLine("Area of Square: "+side * side);
    public void findArea(double length,double breadth) => Console.WriteLine("Area of Rectangle: "+length*breadth);
    public void findArea(float radius) => Console.WriteLine("Area of Circle: "+Math.PI*radius*radius);
}
public class Prog_6
{
    public void start()
    {
        FindArea fa = new FindArea();
        fa.findArea(Convert.ToDouble(5));
        fa.findArea(Convert.ToDouble(5),Convert.ToDouble(5));
        fa.findArea(5.4f);
    }
}

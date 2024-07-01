namespace All_Programs.Practical_2;

interface Shape
{
    public string Circle(double r);
    public string Triangle(double b,double h);
    public string Square(double s);
}
public class Prog_7:Shape
{
    public string Circle(double r)
    {
        return "Area of Circle is: " + Math.PI * r * r;
    }

    public string Triangle(double b, double h)
    {
        return "Area of Triangle is: " + (0.5 * b * h);
    }

    public string Square(double s)
    {
        return "Area of Square is: " + s * s;
    }

    public void start()
    {
        Console.WriteLine(this.Circle(7));
        Console.WriteLine(this.Triangle(5,5));
        Console.WriteLine(this.Square(5));
    }
}

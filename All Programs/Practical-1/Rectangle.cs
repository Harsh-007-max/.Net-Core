namespace All_Programs.Practical_1;

public class Rectangle
{
        public double height, width;
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
        public void CalculateArea()
        {
            Console.WriteLine("Area of Rectangle is: " + Convert.ToString(height * width));
        }
}
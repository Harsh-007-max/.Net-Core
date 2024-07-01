namespace All_Programs.Practical_3;

public class Prog_8
{
    public delegate T calculator<T>(T a,T b);

    public static int Add8(int a, int b) => a + b;
    public static double Subtract8(double a, double b) => a - b;
    public static float Multiplication8(float a, float b) => a * b;
    public static int Division8(int a, int b) => a / b;
    public void start()
    {
        calculator<int> Add = Add8;
        calculator<double> Sub=Subtract8;
        calculator<float> Mul=Multiplication8;
        calculator<int> Div=Division8;
        Console.WriteLine(Add(1,2));
        Console.WriteLine(Sub(1,2));
        Console.WriteLine(Mul(1,2));
        Console.WriteLine(Div(1,2));
    }
}

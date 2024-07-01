namespace All_Programs.Practical_1;
interface Gross
{
    public double Gross_sal();
}

public class Salary1
{
    public double HRA, TA, DA,baseSalary;

    public Salary1(double DA, double TA, double HRA, double baseSalary)
    {
        this.HRA = ( HRA/100)*baseSalary;
        this.DA = (DA/100)*baseSalary;
        this.TA = TA;
        this.baseSalary = baseSalary;
    }

    public double Disp_sal()
    {
        return (this.baseSalary+this.TA+this.DA+this.HRA);
    }
}

public class Employee:Salary1,Gross
{
    public string Name;
    public double Gross_sal()
    {
        return Disp_sal();
    }
    public Employee(double salary, double DA, double TA, double HRA):base(DA,TA,HRA,salary){}
    public void basic_sal()
    {
        Console.WriteLine(Gross_sal());
    }
}

public class Prog_10
{
    public void start()
    {
        Employee e1 = new Employee(100000,0.1,10000,0.05);
        e1.basic_sal();
    }

}
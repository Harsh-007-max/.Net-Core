namespace All_Programs.Practical_1;

public class Salary
{
    double Basic, TA, DA, HRA,total_salary;
    public Salary(double Basic, double TA, double DA=0.1, double HRA= 0.05)
    {
        this.Basic = Basic;
        this.TA = TA;
        this.DA = (DA / 100) * Basic;
        this.HRA = (HRA / 100) * Basic;
    }
    public void CalculateTotalSalary()
    {
        this.total_salary = this.Basic + this.TA + this.DA + this.HRA;
        DisplayTotalSalary();
    }
    public void DisplayTotalSalary() {
        Console.WriteLine("Your total salary is: "+this.total_salary);
    }

}
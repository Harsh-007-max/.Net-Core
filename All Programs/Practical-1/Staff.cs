namespace All_Programs.Practical_1;

public class Staff
{
    public string Name, Designation, Department;
    public int experience;
    public double salary;
    public Staff(string Name,string Department,string Designation,int experience,double salary)
    {
        this.Name = Name;
        this.Department = Department;
        this.Designation = Designation;
        this.experience = experience;
        this.salary = salary;
    }
    public void DisplayStaff()
    {
        Console.WriteLine("Name:" + Name);
        Console.WriteLine("Department:" + Department);
        Console.WriteLine("Designation:" + Designation);
        Console.WriteLine("Experience:" + experience);
        Console.WriteLine("Salary:" + salary);
    }

}
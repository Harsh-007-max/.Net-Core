namespace All_Programs.Practical_3;

public class Hospital{
    public void HospitalDetials()
    {
        Console.WriteLine(this.GetType().Name+" class");
    }
}
public class Apollo:Hospital{
    public void HospitalDetials()
    {
        Console.WriteLine(this.GetType().Name+" class");
    }
}

public class Wockhardt:Hospital{
    public void HospitalDetials()
    {
        Console.WriteLine(this.GetType().Name+" class");
    }
}
public class Gokul_Superspeciality:Hospital{
    public void HospitalDetials()
    {
        Console.WriteLine(this.GetType().Name+" class");
    }
}
public class Prog_5
{
    public void start()
    {
        new Apollo().HospitalDetials();
        new Wockhardt().HospitalDetials();
        new Gokul_Superspeciality().HospitalDetials();
    }
}

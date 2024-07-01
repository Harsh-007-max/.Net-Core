namespace All_Programs.Practical_1;

public class Candidate
{
    int ID, Age;
    string Name;
    double Weight,Height;
    public void GetCandidateDetails(int ID,string Name,double Weight,double Height){
        this.ID = ID;
        this.Name = Name;
        this.Weight = Weight;
        this.Height = Height;
    }
    public void DisplayCandidateDetails(){
        Console.WriteLine(Convert.ToString("ID:"+this.ID));
        Console.WriteLine(Convert.ToString("Name:"+this.Name));
        Console.WriteLine(Convert.ToString("Weight"+this.Weight));
        Console.WriteLine(Convert.ToString("Height:"+this.Height));
    }

}
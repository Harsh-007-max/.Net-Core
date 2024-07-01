namespace All_Programs.Practical_1;

public class Bank_Account
{
    public int Account_No;
    public string Email, User_Name, Account_Type;
    public double Account_Balance;
    public void GetAccountDetails(int Account_No, string Email, string User_Name, string Account_Type,double Account_Balance)
    {
        this.Account_No = Account_No;
        this.Email = Email;
        this.User_Name = User_Name;
        this.Account_Type = Account_Type;
        this.Account_Balance = Account_Balance;
    }
    public void DisplayAccountDetails()
    {
        Console.WriteLine("Account_No:"+this.Account_No);
        Console.WriteLine("Email:"+this.Email);
        Console.WriteLine("User_Name:"+this.User_Name);
        Console.WriteLine("Account_Type:"+this.Account_Type);
        Console.WriteLine("Account_Balance:"+this.Account_Balance);
    }

}
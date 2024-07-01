namespace All_Programs.Practical_1;

public class Account_Details
{
    public int AID;
    public double Balance;
    public Account_Details(int AID,double Balance) {
        this.AID = AID;
        this.Balance = Balance;
    }
    internal class Interest:Account_Details
    {
        public double interest_rate;
        public double interest_amount;
        public Interest(int AID,double Balance):base(AID,Balance){}
        public void SetInterestRate(double interest_rate) => this.interest_rate = interest_rate;
        public void CalculateInterest()
        {
            this.interest_amount += this.Balance * this.interest_rate;
            this.Balance += this.Balance * this.interest_rate;
        }
        public void DisplayInterest()
        {
            Console.WriteLine("Available balance in account: "+this.Balance);
            Console.WriteLine("Total interest is: " + this.interest_amount);
        }
    }
}
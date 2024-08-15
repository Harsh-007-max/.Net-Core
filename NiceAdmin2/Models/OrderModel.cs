namespace NiceAdmin2.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public String PaymentMode { get; set; }
        public double TotalAmount { get; set; }
        public String ShippingAddress { get; set; }
        public int UserID { get; set; }
    }

    public class OrderDropDownModel
    {
        public int OrderID { get; set; }
        public String OrderName{ get; set; }
    }
}

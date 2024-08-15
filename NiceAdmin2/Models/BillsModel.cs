namespace NiceAdmin2.Models
{
    public class BillsModel
    {
        public int BillId { get; set; }
        public string BillNumber { get; set; }

        public DateTime BillDate { get; set; }

        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount{ get; set; }
        public decimal NetAmount { get; set; }
        public int UserID { get; set; }


    }
}

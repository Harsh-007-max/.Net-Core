namespace NiceAdmin2.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public double ProductPrice { get; set; }
        public String ProductCode { get; set; }
        public String Description { get; set; }
        public int UserID { get; set; }
    }
    public class ProductDropDownModel
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
    }
}

namespace NiceAdmin2.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String MobileNo { get; set; }
        public String Address { get; set; }
        public Boolean IsActive { get; set; }
    }
    public class UserDropDownModel
    {
        public int UserID { get; set; }
        public String UserName { get; set; }
    }
}
